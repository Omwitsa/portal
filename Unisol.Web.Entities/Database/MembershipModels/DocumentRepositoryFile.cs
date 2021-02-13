using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class DocumentRepositoryFile
    {
        public int Id { get; set; }
        public int FolderId { get; set; }
        public string FileName { get; set; }
        public string FileDescription { get; set; }
        public string FilePath { get; set; }
        public string UserGroups { get; set; }
        public string FileStatus { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
		public int? FileSize { get; set; }
        public string FileType { get; set; }
        public string FileExt { get; set; }
		public bool Status { get; set; }
		public string CreatedBy { get; set; }

		public  virtual  DocumentRepository Repository { get; set; }

    }
}
