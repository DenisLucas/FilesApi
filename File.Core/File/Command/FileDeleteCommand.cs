using System;
using System.Threading.Tasks;
using MediatR;

namespace File.Core.File.Command
{
    public class FileDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public FileDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
