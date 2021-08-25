using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using File.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace File.Core.File.Command
{
    public class FileDeleteCommandHandler : IRequestHandler<FileDeleteCommand, bool>
    {

        public FileDbContext _context;
        public FileDeleteCommandHandler(FileDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(FileDeleteCommand request, CancellationToken cancellationToken)
        {
            var file = await _context.File.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (System.IO.File.Exists(file.DownloaPath))
            {
                System.IO.File.Delete(file.DownloaPath);
            }

            _context.Remove(file);
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }
    }
}
