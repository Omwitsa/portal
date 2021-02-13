using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FileManagerFiles
    {
        public int FileId { get; set; }
        public int FolderId { get; set; }
        public string FileName { get; set; }
        public string FileDescription { get; set; }
        public string FilePath { get; set; }
        public string FileOwner { get; set; }
        public string FileStatus { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? FileSize { get; set; }
        public string FileType { get; set; }
        public string FileExt { get; set; }

        public FileManagerFolders Folder { get; set; }
    }
}
