using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : Controller
    {
        private InputValidator _validateService;
        private PortalCoreContext _context;
        private IConfiguration _configuration;
        private IHostingEnvironment _hostingEnvironment;
        private readonly TokenValidator _tokenValidator;

        public RepositoryController(PortalCoreContext context, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _validateService = new InputValidator();
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpPost]
        [Route("saveUploadedFiles")]
        public JsonResult SaveUploadedFiles(int folderId, string usercode)
        {
            try
            {
				var users = _context.Users.FirstOrDefault(u => u.UserName.ToUpper().Equals(usercode.ToUpper()));
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });
                }
                var documentFolderLocation = Path.Combine(_hostingEnvironment.WebRootPath, "Documents");
                var folder = _context.DocumentRepository.Find(folderId);
                var path = Path.Combine(documentFolderLocation, folder.FolderPath);
                var file = Request.Form.Files.FirstOrDefault();

                if (!Directory.Exists(path))
                {
                    var di = Directory.CreateDirectory(path);
                }

                if (file == null || file.Length <= 0)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Failed tp upload the file"
                    });
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var uniqueFileName = GetUniqueFileName(fileName);
                var fullPath = Path.Combine(path, uniqueFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var fileUrl = folder.FolderPath.Replace("\\", "/") + '/' + uniqueFileName;
				var status = users.Role == Role.Admin ? true : false;


				var upFile = new DocumentRepositoryFile
                {
                    DateAdded = DateTime.Now,
                    FileName = uniqueFileName,
                    FilePath = fileUrl,
                    FileSize = (int?)file.Length,
                    FileType = file.ContentType,
                    FileExt = fileName.Substring(fileName.LastIndexOf('.') + 1).ToUpper(),
                    UserGroups = folder.UserGroups,
                    FolderId = folderId,
                    Repository = folder,
					CreatedBy = usercode,
					Status = status
				};

                _context.DocumentRepositoryFiles.Add(upFile);

                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Uploaded successfully",
                    Data = fileUrl
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to upload the file, please try again",
                    Error = new Error(ex)
                });
            }
        }

        [HttpGet("[action]")]
        public JsonResult FilesInFolder(int folderId, string usercode, string searchText)
        {
            try
            {
				searchText = searchText ?? "";
				var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });

                return Json(GetFiles(folderId, usercode, searchText));
            }
            catch (Exception e)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to get files, please try again",
                    Error = new Error(e)
                });
            }
        }

		private ReturnData<List<DocumentRepositoryFile>> GetFiles(int folderId, string usercode, string searchText)
		{
			var user = _context.Users.FirstOrDefault(u => u.UserName.ToUpper().Equals(usercode.ToUpper()));
			var files = _context.DocumentRepositoryFiles.Where(f => f.FolderId == folderId 
			&& (f.Status || f.CreatedBy.ToUpper().Equals(usercode.ToUpper()) || user.Role == Role.Admin) 
			&& f.FileName.CaseInsensitiveContains(searchText)).ToList();
			if (files.Count < 1)
				return new ReturnData<List<DocumentRepositoryFile>>
				{
					Success = false,
					Message = "No files found in this folder."
				};

			return new ReturnData<List<DocumentRepositoryFile>>
			{
				Success = true,
				Message = "Files found",
				Data = files
			};
		}


		[HttpGet("[action]")]
		public JsonResult DeleteFiles(int fileId)
		{
			try
			{
				var file = _context.DocumentRepositoryFiles.FirstOrDefault(f => f.Id == fileId);
				if (file != null)
				{
					var documentFolderLocation = Path.Combine(_hostingEnvironment.WebRootPath, "Documents");
					var storedFileUrl = file.FilePath.Split("/");
					foreach(var url in storedFileUrl)
					{
						documentFolderLocation = Path.Combine(documentFolderLocation, url);
					}

					System.IO.File.Delete(documentFolderLocation);

					_context.DocumentRepositoryFiles.Remove(file);
					_context.SaveChanges();
				}
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "File delete successfully"
				});
			}
			catch (Exception e)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occured while trying to get files, please try again",
					Error = new Error(e)
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult publishFiles(int fileId)
		{
			try
			{
				var file = _context.DocumentRepositoryFiles.FirstOrDefault(f => f.Id == fileId);
				file.Status = true;
				_context.SaveChanges();
				return Json(new ReturnData<List<RepositoryModel>>
				{
					Success = true,
					Message = "Published successfully",
				});
			}
			catch(Exception e)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occurred, please try again",
				});
			}
		}

		private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName).Replace(" ", "");
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }

        [HttpPost]
        [Route("createFolder")]
        public JsonResult CreateFolder([FromBody] DocumentRepository request)
        {
            try
            {
                var folderPath = Path.Combine(request.FolderPath ?? "", request.FolderName);
                var documentFolderLocation = Path.Combine(_hostingEnvironment.WebRootPath, "Documents");
                var path = Path.Combine(documentFolderLocation, folderPath);
                DirectoryInfo di = null;
                if (!Directory.Exists(path))
                {
                    di = Directory.CreateDirectory(path);
                    di.Attributes &= ~FileAttributes.ReadOnly;
                }
                if (di.Exists)
                {
                    var repository = new DocumentRepository
                    {
                        FolderName = request.FolderName,
                        FolderPath = folderPath,
                        IsParent = request.IsParent,
                        ParentId = request.ParentId,
                        DateCreated = DateTime.Now,
                        UserGroups = request.UserGroups,
						CreatedBy = request.CreatedBy,
						Status = request.Status
					};
                    _context.DocumentRepository.Add(repository);
                    _context.SaveChanges();

                    return Json(new ReturnData<int>
                    {
                        Success = true,
                        Message = "Folder creation Successifully",
                        Data = repository.Id
                    });
                }

                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Folder creation Failed"

                });

            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to create a folder, please try again",
                    Error = new Error(ex)
                });
            }
        }
		
		[HttpGet("[action]")]
		public JsonResult GetStudentRepository()
		{
			var files = _context.DocumentRepositoryFiles.Select(f => new RepositoryModel
			{
				FileName = f.FileName,
				DateCreated = f.DateAdded.Value.ToShortDateString()
			}).ToList();

			if(files == null)
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "No file found",
				});

			return Json(new ReturnData<List<RepositoryModel>>
			{
				Success = true,
				Message = "Files found",
				Data = files
			});
		}

		[HttpGet("[action]")]
		public JsonResult Publish(int folderId)
		{
			try
			{
				var parentFolder = _context.DocumentRepository.FirstOrDefault(d => d.Id == folderId);
				parentFolder.Status = true;
				_context.SaveChanges();
				return Json(new ReturnData<List<RepositoryModel>>
				{
					Success = true,
					Message = "Published successfully",
				});
			}
			catch(Exception e)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occured, please try again",
				});
			}
		}

		[HttpGet("[action]")]
        public JsonResult GetParentFolders(string usercode)
        {
            try
            {
				var user = _context.Users.FirstOrDefault(u => u.UserName.ToUpper().Equals(usercode.ToUpper()));
				if (user == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Invalid user"
					});

				var userGroupId = user?.UserGroupsId ?? 0 ;
                var userGroupRole = (int)_context.UserGroups.FirstOrDefault(r=>r.Id== userGroupId)?.Role;
                var parentInfo = _context.DocumentRepository.Where(r => r.IsParent).ToList();
                if (user.Role != Role.Admin)
                    parentInfo = parentInfo.Where(r => r.UserGroups == $"{userGroupId}" && (r.Status || r.CreatedBy.ToUpper().Equals(usercode.ToUpper()))).ToList();

                if (parentInfo.Count <= 0)
				{
					var message = "Repository has not been configured, To configure click the add new folder button";
					if(userGroupRole == (int)Role.Student)
						message = "No item found";
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = message,
					});
				}
                   
                var directoryList = (from parent in parentInfo
                                            let subParent = _context.DocumentRepository.Where(r => r.ParentId == parent.Id).ToList()
                                        select new ParentDirectory
                                        {
                                            Parent = parent,
                                            SubRepository = subParent
                                        }).ToList();

                return Json(new ReturnData<List<ParentDirectory>>
                {
                    Success = true,
                    Message = "Folder Found",
                    Data = directoryList
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to get folders, please try again",
                    Error = new Error(ex)
                });
            }
        }
        [HttpGet("[action]")]
        public JsonResult GetParentSubFolders(int parentId, string usercode)
        {
            try
            {
                var parentUserGroupId = _context.DocumentRepository.FirstOrDefault(r => r.Id == parentId).UserGroups;
				var user = _context.Users.FirstOrDefault(u => u.UserName.ToUpper().Equals(usercode.ToUpper()));
                var parentInfo = _context.DocumentRepository.Where(r => r.ParentId == parentId 
				&& (r.Status || user.Role == Role.Admin || r.CreatedBy.ToUpper().Equals(usercode.ToUpper()))).ToList();

                if (parentInfo.Count <= 0)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Folder not Found",
                        Data = parentUserGroupId
                    });
                {
                    var directoryList = (from parent in parentInfo
                                         select new ParentDirectory
                                         {
                                             Parent = parent,
                                             SubRepository = new List<DocumentRepository>()
                                         }).ToList();

                    return Json(new ReturnData<List<ParentDirectory>>
                    {
                        Success = true,
                        Message = "Folder Found",
                        Data = directoryList
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to get folders, please try again",
                    Error = new Error(ex)
                });
            }
        }

        [HttpGet("[action]")]
        public JsonResult EditFolder(int folderId, string folderName, string usercode)
        {
            try {
				var user = _context.Users.FirstOrDefault(u => u.UserName.ToUpper().Equals(usercode.ToUpper()));
				var folder = _context.DocumentRepository.FirstOrDefault(d => d.Id == folderId 
				&& (d.CreatedBy.ToUpper().Equals(usercode.ToUpper()) || user.Role == Role.Admin));
				if(folder == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Editing the Folder not allowed",
					});
				var documentFolderLocation = Path.Combine(_hostingEnvironment.WebRootPath, "Documents");
				var sourceFolder = Path.Combine(documentFolderLocation, folder.FolderPath);
				var destinationFolder = documentFolderLocation;
				var ArrayPath = folder.FolderPath.Split("\\");
				for (int i = 0; i < ArrayPath.Length - 1; i++)
				{
					destinationFolder = Path.Combine(destinationFolder, ArrayPath[i]);
				}

				destinationFolder = Path.Combine(destinationFolder, folderName);

				EditFolders(sourceFolder, destinationFolder);

				folder.FolderName = folderName;
                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Folder Edited Successifully",
                });  
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to Edit the folder, please try again",
                    Error = new Error(ex)
                });
            }
        }

        [HttpGet("[action]")]
        public JsonResult DeleteFolder(int folderId)
        {
            try
            {
				var parentFolder = _context.DocumentRepository.FirstOrDefault(d => d.Id == folderId);
				var childrenFolders = _context.DocumentRepository.Where(d => d.ParentId == folderId).ToList();

				var documentFolderLocation = "";
				var folderPath = "";

				if (childrenFolders != null)
				{
					foreach (var childFilder in childrenFolders)
					{
						documentFolderLocation = Path.Combine(_hostingEnvironment.WebRootPath, "Documents");
						folderPath = Path.Combine(documentFolderLocation, childFilder.FolderPath);
						DeleteFolders(folderPath);

						var filesInFolder = _context.DocumentRepositoryFiles.Where(f => f.FolderId == childFilder.Id).ToList();
						if(filesInFolder.Count > 0)
						{
							_context.DocumentRepositoryFiles.RemoveRange(filesInFolder);
						}
						_context.DocumentRepository.Remove(childFilder);
					}
				}

				if (parentFolder != null)
				{
					documentFolderLocation = Path.Combine(_hostingEnvironment.WebRootPath, "Documents");
					folderPath = Path.Combine(documentFolderLocation, parentFolder.FolderPath);
					DeleteFolders(folderPath);

					var filesInFolder = _context.DocumentRepositoryFiles.Where(f => f.FolderId == parentFolder.Id).ToList();
					if (filesInFolder.Count > 0)
					{
						_context.DocumentRepositoryFiles.RemoveRange(filesInFolder);
					}

					_context.DocumentRepository.Remove(parentFolder);
				}
				
				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Folder Deleted Successifully",
				});
			}
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to Delete the folder, please try again",
                    Error = new Error(ex)
                });
            }
        }

		private void DeleteFolders(string path)
		{
			if (Directory.Exists(path))
			{
				Directory.Delete(path);
			}
		}

		private void EditFolders(string source, string destination)
		{
			if (Directory.Exists(source))
			{
				Directory.Move(source, destination);
			}
		}
	}
}