using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SaleShop.Shared.Entities
{
	public class State
	{
		public int Id { get; set; }

		[Display(Name = "Provincia")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
		public string Name { get; set; } = null!;

		public Country? Country { get; set; }

		public ICollection<City>? Cities { get; set; }

		public int CitiesNumber => Cities == null? 0 : Cities.Count();
	}
}
