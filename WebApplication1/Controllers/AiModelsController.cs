using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiModelsController : ControllerBase
    {
        private readonly BackendContext _context;

        public AiModelsController(BackendContext context)
        {
            _context = context;
        }

        // GET: api/AiModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AiModel>>> GetAiModels()
        {
            return await _context.AiModels.ToListAsync();
        }

        // GET: api/AiModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AiModel>> GetAiModel(long id)
        {
            var aiModel = await _context.AiModels.FindAsync(id);

            if (aiModel == null)
            {
                return NotFound();
            }

            return aiModel;
        }

        // PUT: api/AiModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAiModel(long id, AiModel aiModel)
        {
            if (id != aiModel.AiModelId)
            {
                return BadRequest();
            }

            _context.Entry(aiModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AiModelExists(id))
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

        // POST: api/AiModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AiModel>> PostAiModel(AiModel aiModel)
        {
            _context.AiModels.Add(aiModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAiModel", new { id = aiModel.AiModelId }, aiModel);
        }

        // DELETE: api/AiModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAiModel(long id)
        {
            var aiModel = await _context.AiModels.FindAsync(id);
            if (aiModel == null)
            {
                return NotFound();
            }

            _context.AiModels.Remove(aiModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AiModelExists(long id)
        {
            return _context.AiModels.Any(e => e.AiModelId == id);
        }

        [HttpGet("ByAuthor/{aiModelAuthor}")]
        public async Task<ActionResult<IEnumerable<AiModel>>> GetAiModelsByAuthor(string aiModelAuthor)
        {
            var aiModels = await _context.AiModels
                                        .Where(m => m.AiModelAuthor == aiModelAuthor)
                                        .ToListAsync();

            if (aiModels == null || aiModels.Count == 0)
            {
                return NotFound();
            }

            return aiModels;
        }

    }
}
