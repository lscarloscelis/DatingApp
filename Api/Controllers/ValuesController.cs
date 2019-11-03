using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repos.Values;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesRepo valuesRepo;
        public ValuesController(IValuesRepo valuesRepo)
        {
            this.valuesRepo = valuesRepo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(valuesRepo.getValues());
        }
    }
}
