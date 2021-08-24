using System;
using MediatR;

namespace File.Core.File.Query
{
    public class FileDownloadQuery : IRequest<byte[]>
    {
        public int Id { get; set; }
        public FileDownloadQuery(int id)
        {
            Id = id;
            
        }
    }
}
