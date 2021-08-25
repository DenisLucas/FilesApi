
using FluentValidation;

namespace File.Core.File.Query
{
    public class FileDownloadQueryValidator : AbstractValidator<FileDownloadQuery>
    {
        
        public FileDownloadQueryValidator()
        {
            RuleFor(x=> x.Id)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .NotEmpty()
            .WithMessage("you need an id to run this");
            
        }
    }
}
