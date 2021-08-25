using System;
using File.Domain.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace File.Core.File.Command
{
    public class FileEditCommand
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }

    }
    public class FileEditCommandId : IRequest<ViewModelFiles>
    {
        public int Id { get; set; }
        public FileEditCommand EditFile { get; set; }
        public FileEditCommandId(int id, FileEditCommand file)
        {
            Id = id;
            EditFile = file;
        }
    }
}
