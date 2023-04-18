using System.ComponentModel.DataAnnotations;

namespace SaleShop.Shared.Entities
{
	public class Category
	{
		public int Id { get; set; }

		[Display(Name = "Categoria")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
		public string Name { get; set; } = null!;

        public ICollection<ProductCategory>? ProductCategories { get; set; }

        [Display(Name = "Productos")]
        public int ProductCategoriesNumber => ProductCategories == null ? 0 : ProductCategories.Count;
    }
}
