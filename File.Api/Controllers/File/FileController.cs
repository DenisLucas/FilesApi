using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using File.Core.File.Command;
using File.Domain.ModelVIews;
using File.Util.Helpers;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace File.Api.Controllers.File
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UrlHelper _urlHelper;
        public FileController(IMediator mediator, IMapper mapper, IWebHostEnvironment environment, UrlHelper urlHelper) 
        {
            _mapper = mapper;
            _mediator = mediator;
            _environment = environment;
            _urlHelper = urlHelper;
        }



        [HttpPost("upload")]
        public async Task<IActionResult> uploadVideo([FromForm] FileUploadCommand arquivo)
        {
            if (arquivo.File.Length > 0)
            {
            
                var command = await _mediator.Send(arquivo);
                var file = _mapper.Map<ModelViewFiles>(command);
                var url = _urlHelper.getUri(command.Id.ToString()); 
                return Created(url,file);
            }
            return BadRequest();
            
        }
    }
}
