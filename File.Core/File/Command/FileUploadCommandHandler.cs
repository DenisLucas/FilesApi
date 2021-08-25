using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using File.Core.File.Command;
using File.Domain.Entities;
using File.Domain.ViewModel;
using File.Infrastructure;
using MediatR;

namespace File.Core.File.Commands
{
    public class FileUploadCommandHandler : IRequestHandler<FileUploadCommand, Files>
    {
        public FileDbContext _context;
        public IMapper _mapper;
        public FileUploadCommandHandler(FileDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Files> Handle(FileUploadCommand request, CancellationToken cancellationToken)
        {
            var path = @"Downloads/";
            using (FileStream fileStream = System.IO.File.Create(@"" + path + request.File.FileName))
            {
                await request.File.CopyToAsync(fileStream);
                fileStream.Flush();
                
               
            }
            var file = new ViewModelFiles
            {
                FileName = request.File.FileName,
                FileSize = request.File.Length,
                DownloaPath = path + request.File.FileName
            };
            var fileMapped = _mapper.Map<Files>(file);

            await _context.File.AddAsync(fileMapped);
            await _context.SaveChangesAsync();
 
            return fileMapped;
        }
    }
}
