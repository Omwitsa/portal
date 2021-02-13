using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class DocumentRepository
    {
        public DocumentRepository()
        {
            DocumentRepositoryFiles = new List<DocumentRepositoryFile>();
        }
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string FolderPath { get; set; }
        public bool IsParent { get; set; }
        public int ParentId { get; set; }
        public string UserGroups { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
		public bool Status { get; set; }
		public string CreatedBy { get; set; }

		public List<DocumentRepositoryFile> DocumentRepositoryFiles { get; set; }
    }

    public class ParentDirectory
    {
        public DocumentRepository Parent { get; set; }
        public List<DocumentRepository> SubRepository { get; set; }
    }
}
