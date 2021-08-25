using System;
using File.Core.File.Command;
using File.Domain.Entities;
using FluentValidation;

namespace File.Core.File.Query
{
    public class FileUploadCommandValidator : AbstractValidator<FileUploadCommand>
    {
        public FileUploadCommandValidator()
        {
            RuleFor(x=> x.File.FileName)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("File precisa ter um nome maior que 3 caracteres");
            

            
        }
    }
}
