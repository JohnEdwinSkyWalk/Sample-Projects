using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using JoEdAngular2;


namespace JoEdAngular2.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class AllMailsController : ControllerBase
    {
                private readonly JoEdContext _context;
        private static readonly string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

        public AllMailsController(JoEdContext context)
        {
            _context = context;
        }

        // GET: api/AllMails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllMailsModel>>> GetAllMailsModel()
        {
            return await _context.AllMailsModel.ToListAsync();
        }

        // GET: api/AllMails/5
        

        [HttpGet("{id}")]
        public  ActionResult<IEnumerable<AllMailsModel>> GetAllMails(int id)
        {
             //var allMailsModel = await _context.AllMailsModel.FindAsync(id);
        var allMailsModel =  AllMailsService.Mails().ToList();
            

            return  allMailsModel;
        }
        // PUT: api/AllMails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllMailsModel(int id, AllMailsModel allMailsModel)
        {
            if (id != allMailsModel.id)
            {
                return BadRequest();
            }

            _context.Entry(allMailsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllMailsModelExists(id))
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

        // POST: api/AllMails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AllMailsModel>> PostAllMailsModel(AllMailsModel allMailsModel)
        {
            _context.AllMailsModel.Add(allMailsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllMailsModel", new { id = allMailsModel.id }, allMailsModel);
        }

        // DELETE: api/AllMails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllMailsModel(int id)
        {
            var allMailsModel = await _context.AllMailsModel.FindAsync(id);
            if (allMailsModel == null)
            {
                return NotFound();
            }

            _context.AllMailsModel.Remove(allMailsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllMailsModelExists(int id)
        {
            return _context.AllMailsModel.Any(e => e.id == id);
        }
    }
}
