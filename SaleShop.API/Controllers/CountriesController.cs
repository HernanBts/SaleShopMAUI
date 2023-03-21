using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleShop.API.Data;
using SaleShop.Shared.Entities;

namespace SaleShop.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries
                .Include(x=>x.States)
                .ToListAsync());
        }

        [HttpGet("full")]
        public async Task<IActionResult> GetFullAsync()
        {
            return Ok(await _context.Countries
                .Include(x => x.States!)
                .ThenInclude(x => x.Cities)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            try
            {
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (DbUpdateException dbUpdate)
            {
                if (dbUpdate.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un pais con el mismo nombre.");
                }
                return BadRequest(dbUpdate.Message);
            }
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            try
            {
                _context.Update(country);
                await _context.SaveChangesAsync();
                return Ok(country);
            }
			catch (DbUpdateException dbUpdate)
			{
				if (dbUpdate.InnerException!.Message.Contains("duplicate"))
				{
					return BadRequest("Ya existe un pais con el mismo nombre.");
				}
				return BadRequest(dbUpdate.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
