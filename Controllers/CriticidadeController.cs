using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CriticidadeController : ControllerBase
    {
        // GET: api/Criticidade
        [HttpGet]
        public ActionResult<IEnumerable<Criticidade>> Get()
        {
            var listaCriticidade = new Criticidade();
            return listaCriticidade.ListaCriticidade();
        }

       
    }
}
