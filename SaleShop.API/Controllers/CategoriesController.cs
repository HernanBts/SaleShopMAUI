using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleShop.API.Data;
using SaleShop.Shared.Entities;

namespace SaleShop.API.Controllers
{
	[ApiController]
	[Route("/api/categories")]
	public class CategoriesController : ControllerBase
	{
		private readonly DataContext _context;

		public CategoriesController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await _context.Categories.ToListAsync());
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetAsync(int id)
		{
			var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return Ok(category);
		}

		[HttpPost]
		public async Task<ActionResult> PostAsync(Category category)
		{
			try
			{
				_context.Categories.Add(category);
				await _context.SaveChangesAsync();
				return Ok(category);
			}
			catch (DbUpdateException dbUpdate)
			{
				if (dbUpdate.InnerException!.Message.Contains("duplicate"))
				{
					return BadRequest("Ya existe una categoria con el mismo nombre.");
				}
				return BadRequest(dbUpdate.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public async Task<ActionResult> PutAsync(Category category)
		{
			try
			{
				_context.Update(category);
				await _context.SaveChangesAsync();
				return Ok(category);
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
			var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

			if (category == null)
			{
				return NotFound();
			}

			_context.Remove(category);
			await _context.SaveChangesAsync();
			return NoContent();
		}
	}
}
