
using System.Threading.Tasks;
using AutoMapper;
using File.Core.File.Command;
using File.Core.File.Query;
using File.Domain.ViewModel;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UrlHelper _urlHelper;
        public FileController(IMediator mediator, IMapper mapper, IWebHostEnvironment environment, UrlHelper urlHelper) 
        {
            _mapper = mapper;
            _mediator = mediator;
            _urlHelper = urlHelper;
        }



        [HttpPost("upload")]
        public async Task<IActionResult> uploadFile([FromForm] FileUploadCommand file)
        {
            if (file.File.Length > 0)
            {
            
                var command = await _mediator.Send(file);
                var mappedfile = _mapper.Map<ViewModelFiles>(command);
                var url = _urlHelper.getUri(command.Id.ToString()); 
                return Created(url,mappedfile);
            }
            return BadRequest();   
        }
        [HttpGet("download/{id}")]
        public async Task<IActionResult> downloadFile(int id)
        {
            var query = new FileDownloadQuery(id);
            var file = await _mediator.Send(query);
            if (file != null) return File(file, "application/octet-stream");
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteFile(int id)
        {
            var command = new FileDeleteCommand(id);
            var file = await _mediator.Send(command);
            if (file) return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> editFile(int id, [FromForm] FileEditCommand commandId)
        {    
            var command = new FileEditCommandId(id,commandId);
            var file = await _mediator.Send(command);
            if (file != null) return Ok(file);
            return BadRequest();
        }


    }
}