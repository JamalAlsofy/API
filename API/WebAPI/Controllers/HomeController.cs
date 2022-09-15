using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("conn")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public List<string> ConnectionCheck()
        {
            return new List<string>() { "connection", "Connection Successful" };
        }
    }

    /*
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
            CompanyResponseDto entity =new CompanyResponseDto().fromModel(item);
            return Ok(entity);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyAddDto request)
        {
            try
            {
                Company entity = request.toModel(request);
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); //return BadRequest(ModelState.GetErrorMessagesDicLst());
                return Ok(await _service.Add(entity));
                //if (ModelState.IsValid)
                //{
                //    return Ok(await _service.Add(entity));
                //}
            }
            catch (Exception ex)
            {
                //return (IActionResult)ExceptionData.Get<object>(ex);
            }
        }

        // PUT api/<CompanyController>
        [HttpPut]
        public async Task<IActionResult> Put(CompanyEditDto request)
        {
            Company entity = request.toModel(request);
            return Ok(await _service.Edit(entity));
        }
        
        //
        // // PUT api/<CompanyController>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, Company entity)
        //{
        //    return Ok(await _service.Edit(entity));
        //}
        //

    // DELETE api/<CompanyController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.Delete(id));
    }
  }
*/

}
