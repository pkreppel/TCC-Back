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
    public class SensoresBarragemController : ControllerBase
    {
        private readonly DataContext _context;

        public SensoresBarragemController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SensoresBarragem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensoresBarragem>>> GetSensoresBarragem()
        {
            return await _context.SensoresBarragem.ToListAsync();
        }

        // GET: api/SensoresBarragem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensoresBarragem>> GetSensoresBarragem(int id)
        {
            var sensoresBarragem = await _context.SensoresBarragem.FindAsync(id);

            if (sensoresBarragem == null)
            {
                return NotFound();
            }

            return sensoresBarragem;
        }

        // PUT: api/SensoresBarragem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensoresBarragem(int id, SensoresBarragem sensoresBarragem)
        {
            if (id != sensoresBarragem.SensorId)
            {
                return BadRequest();
            }

            _context.Entry(sensoresBarragem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensoresBarragemExists(id))
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

        // POST: api/SensoresBarragem
        [HttpPost]
        public async Task<ActionResult<SensoresBarragem>> PostSensoresBarragem(SensoresBarragem sensoresBarragem)
        {
            sensoresBarragem.HoraMonitoramento = DateTime.UtcNow;
            _context.SensoresBarragem.Add(sensoresBarragem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensoresBarragem", new { id = sensoresBarragem.SensorId }, sensoresBarragem);
        }

        // DELETE: api/SensoresBarragem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SensoresBarragem>> DeleteSensoresBarragem(int id)
        {
            var sensoresBarragem = await _context.SensoresBarragem.FindAsync(id);
            if (sensoresBarragem == null)
            {
                return NotFound();
            }

            _context.SensoresBarragem.Remove(sensoresBarragem);
            await _context.SaveChangesAsync();

            return sensoresBarragem;
        }

        private bool SensoresBarragemExists(int id)
        {
            return _context.SensoresBarragem.Any(e => e.SensorId == id);
        }
    }
}
