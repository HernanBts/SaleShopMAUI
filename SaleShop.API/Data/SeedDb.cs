using SaleShop.Shared.Entities;

namespace SaleShop.API.Data
{
	public class SeedDb
	{
		private DataContext _context;

		public SeedDb(DataContext context) 
		{
			_context = context;
		}

		public async Task SeedAsync()
		{
			await _context.Database.EnsureCreatedAsync();
			await CheckCountriesAsync();
		}

		private async Task CheckCountriesAsync()
		{
			if (!_context.Countries.Any()) 
			{
				_context.Countries.Add(new Country { Name = "Argentina" });
				_context.Countries.Add(new Country { Name = "Colombia" });
				_context.Countries.Add(new Country { Name = "Uruguay" });
				await _context.SaveChangesAsync();
			}
		}
	}
}
