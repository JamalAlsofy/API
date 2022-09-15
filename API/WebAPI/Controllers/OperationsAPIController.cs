using Library.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("operationsAPI")]
    [ApiController]
    public class OperationsAPIController : ControllerBase
    {
        private readonly IOperationsAPIService _service;
        private readonly ILogger<OperationsAPIController> _logger;

        public OperationsAPIController(IOperationsAPIService service, ILogger<OperationsAPIController> logger)
        {
            _service = service;
            _logger = logger;
        }
        // GET: api/<OperationsAPIController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _service.GetAll();
            return Ok(items);
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetPaga([FromQuery]int pageNumber, int pageSize)
        {
            var items = await _service.GetPaga(pageNumber, pageSize);
            return Ok(items);
        }
    }
}
