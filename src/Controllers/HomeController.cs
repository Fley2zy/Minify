using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Minify.Controllers
{
    [Controller]
    [Route("/redirect")]
    public class RedirectController : ControllerBase
    {
        [HttpGet]
        [Route("/redirect/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            MongoRepository repo = new MongoRepository();
            var document = await repo.Get(id);
            
            return Redirect(document.Url);
        }
    }
}