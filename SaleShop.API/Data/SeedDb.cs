﻿using SaleShop.Shared.Entities;

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
			await CheckCategoriesAsync();
		}

		private async Task CheckCountriesAsync()
		{
			if (!_context.Countries.Any())
			{
				_context.Countries.Add(new Country
				{
					Name = "Argentina",
					States = new List<State>
					{
						new State
						{
							Name = "Chaco",
							Cities = new List<City>
							{
								new City{ Name = "Resistencia" },
								new City{ Name = "Barranqueras" },
								new City{ Name = "Fontana" },
								new City{ Name = "Tirol" },
								new City{ Name = "Margarita Belen"}
							}
						},
						new State
							{
								Name = "Cordoba",
								Cities = new List<City>
							{
								new City{ Name = "Cordoba" },
								new City{ Name = "Villa Carlos Paz" },
								new City{ Name = "General Belgrano" },
								new City{ Name = "La Falda" }
							}
						}
					}
				});
				_context.Countries.Add(new Country
				{
					Name = "Colombia",
					States = new List<State>()
					{
						new State()
						{
							Name = "Antioquia",
							Cities = new List<City>() {
								new City() { Name = "Medellín" },
								new City() { Name = "Itagüí" },
								new City() { Name = "Envigado" },
								new City() { Name = "Bello" },
								new City() { Name = "Rionegro" },
							}
						},
						new State()
						{
							Name = "Bogotá",
							Cities = new List<City>() {
								new City() { Name = "Usaquen" },
								new City() { Name = "Champinero" },
								new City() { Name = "Santa fe" },
								new City() { Name = "Useme" },
								new City() { Name = "Bosa" },
							}
						},
					}
				});

				_context.Countries.Add(new Country
				{
					Name = "Estados Unidos",
					States = new List<State>()
					{
						new State()
						{
							Name = "Florida",
							Cities = new List<City>() {
								new City() { Name = "Orlando" },
								new City() { Name = "Miami" },
								new City() { Name = "Tampa" },
								new City() { Name = "Fort Lauderdale" },
								new City() { Name = "Key West" },
							}
						},
						new State()
						{
							Name = "Texas",
							Cities = new List<City>() {
								new City() { Name = "Houston" },
								new City() { Name = "San Antonio" },
								new City() { Name = "Dallas" },
								new City() { Name = "Austin" },
								new City() { Name = "El Paso" },
							}
						},
					}
				});

				await _context.SaveChangesAsync();
			}
		}
		private async Task CheckCategoriesAsync()
		{
			if (!_context.Categories.Any())
			{
				_context.Categories.Add(new Category { Name = "Electronica" });
				_context.Categories.Add(new Category { Name = "Audio" });
				_context.Categories.Add(new Category { Name = "Telefonos" });
				await _context.SaveChangesAsync();
			}
		}
	}
}
