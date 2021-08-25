using System;
using FluentValidation;

namespace File.Core.File.Command
{
    public class FileEditCommandValidator : AbstractValidator<FileEditCommand>
    {
        public FileEditCommandValidator()
        {
            RuleFor(x => x.FileName)
            .MinimumLength(3)
            .When(x=> x.FileName != null)
            .WithMessage("File precisa ter um nome maior que 3 caracteres");
               
            RuleFor(x => x.File.FileName)
            .MinimumLength(3)
            .When(x=> x.FileName == null)
            .WithMessage("File precisa ter um nome maior que 3 caracteres");
        }
    }
}
