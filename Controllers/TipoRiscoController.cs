using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoRiscoController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoRiscoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TiposRisco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoRisco>>> GetTiposRisco()
        {
            var tiposRisco = await _context.TipoRisco.ToListAsync();
            var tiposRiscoReturn = tiposRisco.Select(p => new
            {
                tipoRiscoID = p.TipoRiscoId,
                nomeTipoRisco = p.NomeTipoRisco,
                criticidade = p.Criticidade,
                localTipoRisco = p.LocalTipoRisco,
                editDelete =  _context.Risco.Where(i => i.TipoRiscoId == p.TipoRiscoId ).Count() == 0
            }).OrderBy(p=> p.nomeTipoRisco);
            return Ok(tiposRiscoReturn);
        }

        // GET: api/TiposRisco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoRisco>> GetTipoRisco(int id)
        {
            var tipoRisco = await _context.TipoRisco.FindAsync(id);

            if (tipoRisco == null)
            {
                return NotFound();
            }

            return tipoRisco;
        }

        // PUT: api/TiposRisco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoRisco(int id, TipoRisco tipoRisco)
        {
            if (id != tipoRisco.TipoRiscoId)
            {
                return BadRequest();
            }

            _context.Entry(tipoRisco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoRiscoExists(id))
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

        // POST: api/TiposRisco
        [HttpPost]
        public async Task<ActionResult<TipoRisco>> PostTipoRisco(TipoRisco tipoRisco)
        {
            _context.TipoRisco.Add(tipoRisco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoRisco", new { id = tipoRisco.TipoRiscoId }, tipoRisco);
        }

        // DELETE: api/TiposRisco/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoRisco>> DeleteTipoRisco(int id)
        {
            var tipoRisco = await _context.TipoRisco.FindAsync(id);
            var countRiscosTipoRisco = _context.Risco.Where(p => p.TipoRiscoId == id).Count();
            if (tipoRisco == null)
            {
                return NotFound();
            }

            if (countRiscosTipoRisco > 0)
            {
                return BadRequest("Este Tipo de Risco está vinculado a um ou mais riscos");
            }

            _context.TipoRisco.Remove(tipoRisco);
            await _context.SaveChangesAsync();

            return tipoRisco;
        }

        private bool TipoRiscoExists(int id)
        {
            return _context.TipoRisco.Any(e => e.TipoRiscoId == id);
        }
    }
}
