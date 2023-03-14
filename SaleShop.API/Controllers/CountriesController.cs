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
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Countries.Add(country); 
            await _context.SaveChangesAsync();
            return Ok(country);
        }
    }
}
