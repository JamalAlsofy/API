using Library.Domain.Entities;
using Library.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.RequestDto.ProviderRequest;
using WebAPI.Models.ResponseDto.ProviderResponse;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("provider")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _service;
        private readonly ILogger<ProviderController> _logger;

        public ProviderController(IProviderService service, ILogger<ProviderController> logger)
        {
            _service = service;
            _logger = logger;
        }
        // GET: api/<ProviderController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _service.GetAll();
            IList<ProviderResponseDto> entities = new ProviderResponseDto().fromModel(items);
            return Ok(entities);
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.Details(id);
            ProviderResponseDto entity = new ProviderResponseDto().fromModel(item);
            return Ok(entity);
        }

        // POST api/<ProviderController>
        [HttpPost]
        public async Task<IActionResult> Post(ProviderAddDto request)
        {
            try
            {

                Provider entity = request.toModel(request);
                var result = await _service.Add(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return (IActionResult)ExceptionData.Get(ex);
            }
        }

        // PUT api/<ProviderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProviderEditDto request)
        {
            try
            {
                var item = await _service.Details(id);
                Provider entity = request.toModel(item,request);
                entity.id = id;
                var result = await _service.Edit(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return (IActionResult)ExceptionData.Get(ex);
            }

        }

        // DELETE api/<ProviderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return (IActionResult)ExceptionData.Get(ex);
            }
        }

    }
}
