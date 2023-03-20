using System.ComponentModel.DataAnnotations;

namespace SaleShop.Shared.Entities
{
	public class City
	{
		public int Id { get; set; }

		[Display(Name = "Ciudad")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
		public string Name { get; set; } = null!;

		public State? State { get; set; }
	}
}
