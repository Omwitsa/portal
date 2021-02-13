using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FileManagerFolders
    {
        public FileManagerFolders()
        {
            FileManagerFiles = new HashSet<FileManagerFiles>();
        }

        public int FolderId { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public string FolderPath { get; set; }
        public string FolderOwner { get; set; }
        public string FolderStatus { get; set; }
        public DateTime? DateAdded { get; set; }

        public ICollection<FileManagerFiles> FileManagerFiles { get; set; }
    }
}
