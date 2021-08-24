using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using File.Core.File.Query;
using File.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace File.Core.File.Handlers.Query
{
    public class FileDownloadHandler : IRequestHandler<FileDownloadQuery, byte[]>
    {
        public FileDbContext _context;
        public IMapper _mapper;
        public FileDownloadHandler(FileDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<byte[]> Handle(FileDownloadQuery request, CancellationToken cancellationToken)
        {
            var fileData = await _context.File.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            var path = "" + fileData.DownloaPath;
            var bytes = System.IO.File.ReadAllBytes(path);
            return bytes;

        }
    }
}
