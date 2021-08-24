using System;

namespace File.Domain.Entities
{
    public class Files
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public float FileSize { get; set; }
        public string DownloaPath { get; set; }
    }
}
