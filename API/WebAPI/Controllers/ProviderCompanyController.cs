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
using WebAPI.Models.RequestDto.ProviderCompanyRequest;
using WebAPI.Models.ResponseDto.ProviderCompanyResponse;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("providerCmpny")]
    [ApiController]
    public class ProviderCompanyController : ControllerBase
    {
        private readonly IProviderCompaniesService _service;
        private readonly ILogger<ProviderCompanyController> _logger;

        public ProviderCompanyController(IProviderCompaniesService service, ILogger<ProviderCompanyController> logger)
        {
            _service = service;
            _logger = logger;
        }
        // GET: api/<ProviderCompanyController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _service.GetAll();
            IList<ProviderCompanyDto> entities = new ProviderCompanyDto().fromModel(items);
            return Ok(entities);
        }

        // GET api/<ProviderCompanyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.Details(id);
            ProviderCompanyDto entity = new ProviderCompanyDto().fromModel(item);
            return Ok(entity);
        }

        // POST api/<ProviderCompanyController>
        [HttpPost]
        public async Task<IActionResult> Post(ProviderCompanyAddDto request)
        {
            try
            {

                ProviderCompany entity = request.toModel(request);
                var result = await _service.Add(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return (IActionResult)ExceptionData.Get(ex);
            }
        }

        // PUT api/<ProviderCompanyController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProviderCompanyEditDto request)
        {
            try
            {
                var item = await _service.Details(id);
                ProviderCompany entity = request.toModel(item,request);
                entity.id = id;
                var result = await _service.Edit(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return (IActionResult)ExceptionData.Get(ex);
            }

        }

        // DELETE api/<ProviderCompanyController>/5
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
