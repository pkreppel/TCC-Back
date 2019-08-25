using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using System.Globalization;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RiscoController : ControllerBase
    {
        private readonly DataContext _context;

        public RiscoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Riscos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Risco>>> GetRiscos()
        {
            var riscos = await _context.Risco.ToListAsync();
            var tiposRisco = await _context.TipoRisco.ToListAsync();
            var riscosReturn = riscos.Select(p => new
            {
                riscoID = p.RiscoId,
                descricaoRisco = p.DescricaoRisco,
                tipoRiscoID = p.TipoRiscoId,
                nomeTipoRisco = tiposRisco.Where(i => p.TipoRiscoId == i.TipoRiscoId).FirstOrDefault().NomeTipoRisco,
                criticidade = tiposRisco.Where(i => p.TipoRiscoId == i.TipoRiscoId).FirstOrDefault().Criticidade,
                localTipoRisco = tiposRisco.Where(i => p.TipoRiscoId == i.TipoRiscoId).FirstOrDefault().LocalTipoRisco,
                dataCadastro = p.DataCadastro.ToString("dd/M/yyyy hh:mm:ss", CultureInfo.InvariantCulture)

            });
            return Ok(riscosReturn);
        }

        //public ActionResult<IEnumerable<Risco>> GetRiscos()
        //{
        //    var riscos =  _context.Risco.ToList();
        //    var tiposRisco =  _context.TipoRisco.ToList();
        //    var riscosReturn = riscos.Select(p => new
        //    {
        //        RiscoID = p.RiscoId,
        //        DescricaoRisco = p.DescricaoRisco,
        //        TipoRiscoID = p.TipoRiscoId,
        //        NomeTipoRisco = tiposRisco.Where(i => p.TipoRiscoId == i.TipoRiscoId).FirstOrDefault().NomeTipoRisco,
        //        DataCadastro = p.DataCadastro.ToString("dd/M/yyyy hh:mm:ss", CultureInfo.InvariantCulture)

        //    });
        //    return Ok(riscosReturn);
        //}

        // GET: api/Riscos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Risco>> GetRisco(int id)
        {
            var risco = await _context.Risco.FindAsync(id);

            if (risco == null)
            {
                return NotFound();
            }

            return risco;
        }

        // PUT: api/Riscos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRisco(int id, [FromBody] Risco risco)
        {
            risco.DataCadastro = DateTime.UtcNow;
            if (id != risco.RiscoId)
            {
                return BadRequest();
            }

            _context.Entry(risco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiscoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Riscos
        [HttpPost]
        public ActionResult<Risco> PostRisco([FromBody] Risco risco)
        {
            risco.DataCadastro = DateTime.UtcNow;
            _context.Risco.Add(risco);
            _context.SaveChanges();

            return CreatedAtAction("GetRisco", new { id = risco.RiscoId }, risco);
        }

        // DELETE: api/Riscos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Risco>> DeleteRisco(int id)
        {
            var risco = await _context.Risco.FindAsync(id);
            if (risco == null)
            {
                return NotFound();
            }

            _context.Risco.Remove(risco);
            await _context.SaveChangesAsync();

            return risco;
        }

        private bool RiscoExists(int id)
        {
            return _context.Risco.Any(e => e.RiscoId == id);
        }
    }
}
