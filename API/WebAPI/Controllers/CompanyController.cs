using Library.Domain.Entities;
using Library.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Extensions;
using WebAPI.Models;
using WebAPI.Models.RequestDto.CompanyRequest;
using WebAPI.Models.ResponseDto.CompanyResponse;
using WebAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompaniesService _service;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompaniesService service, ILogger<CompanyController> logger)
        {
            _service = service;
            _logger = logger;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _service.GetAll();
            IList<CompanyResponseDto> entities = new CompanyResponseDto().fromModel(items);
            return Ok(entities);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.Details(id);
            CompanyResponseDto entity = new CompanyResponseDto().fromModel(item);
            return Ok(entity);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<IActionResult> Post(CompanyAddDto request) // [FromBody]
        {
            try
            {               
                if (!ModelState.IsValid)
                     return BadRequest(ModelState.GetErrorMessagesDicLst()); // return BadRequest(ModelState);
                
                Company entity = request.toModel(request);
                var result = await _service.Add(entity);
                return Ok(result);

                //if (isAdd)
                //    return Ok(ResultResponse.GetSuccess());
                //else
                //    return Conflict(ResultResponse.GetError());
            }
            catch (Exception ex)
            {
                return (IActionResult)ExceptionData.Get(ex);
            }
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CompanyEditDto request)
        {
            try
            {
                Company entity = request.toModel(request);
                entity.id = id;
                var result = await _service.Edit(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return (IActionResult)ExceptionData.Get(ex);
            }

        }

        /*
         // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Company entity)
        {
            return Ok(await _service.Edit(entity));
        }
        */

        // DELETE api/<CompanyController>/5
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
