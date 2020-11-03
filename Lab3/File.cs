using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public class File
    {
        public int FileID { get; set; }

        public string FileName { get; set; }

        public int FileSize { get; set; }

        public string ContentType { get; set; }

        public string FileExtension { get; set; }

        public byte[] FileContent { get; set; }
    }
}