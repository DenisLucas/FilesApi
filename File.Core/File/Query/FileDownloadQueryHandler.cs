using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using File.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace File.Core.File.Query
{
    public class FileDownloadQueryHandler : IRequestHandler<FileDownloadQuery, byte[]>
    {
        public FileDbContext _context;
        public IMapper _mapper;
        public FileDownloadQueryHandler(FileDbContext context, IMapper mapper)
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
