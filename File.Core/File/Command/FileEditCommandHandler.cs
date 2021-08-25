using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using File.Domain.ViewModel;
using File.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace File.Core.File.Command
{
    public class FileEditCommandHandler : IRequestHandler<FileEditCommandId, ViewModelFiles>
    {

        public FileDbContext _context;
        public IMapper _mapper;
        public FileEditCommandHandler(FileDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ViewModelFiles> Handle(FileEditCommandId request, CancellationToken cancellationToken)
        {
            var path = @"Downloads/";

            var file = await _context.File.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            var name = file.FileName;
            if (System.IO.File.Exists(path + file.FileName))
            {}
            System.IO.File.Delete(path + name);
            if (request.EditFile.FileName == null)
            {
                file.FileName = request.EditFile.File.FileName;
            }
            else
            {
                file.FileName = request.EditFile.FileName;
            }
            using (FileStream fileStream = System.IO.File.Create(@"" + path + file.FileName))
            {
                await request.EditFile.File.CopyToAsync(fileStream);
                fileStream.Flush();   
            }
            file.FileSize = request.EditFile.File.Length;
            file.DownloaPath = path + file.FileName;
            await _context.SaveChangesAsync();
            return _mapper.Map<ViewModelFiles>(file);
        }
    }
}
