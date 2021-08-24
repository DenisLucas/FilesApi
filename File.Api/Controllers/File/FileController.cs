using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using File.Core.File.Command;
using File.Core.File.Query;
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
                var mappedfile = _mapper.Map<ModelViewFiles>(command);
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
    }
}