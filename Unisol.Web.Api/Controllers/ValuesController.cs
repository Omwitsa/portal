using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly UnisolAPIdbContext _context;

        public ValuesController(UnisolAPIdbContext context)
        {
            _context = context;
        }

        // GET: api/AspNetUsers
        [HttpGet]
        public string Get()
        {
			return DateTime.UtcNow.ToString("F") + " API is up and Running";
		}

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          
        }
    }
}