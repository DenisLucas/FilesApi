using File.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace File.Core.File.Command
{
    public class FileUploadCommand : IRequest<Files>
    {
        public IFormFile File { get; set; }
    }
}