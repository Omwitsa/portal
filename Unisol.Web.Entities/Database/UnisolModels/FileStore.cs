using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FileStore
    {
        public int Id { get; set; }
        public byte[] FileContent { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }
        public int Newsid { get; set; }
    }
}
