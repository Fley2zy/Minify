using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Minify.Model;

namespace Minify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinifyController : ControllerBase
    {
        private MongoRepository repo = new MongoRepository();
        [HttpPost]
        public string Add([FromBody] MinifyData data)
        {
            repo.Add(data);
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public IEnumerable<MinifyData> Get()
        {
            return repo.Get();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            repo.Delete(id);
        }
    }
}