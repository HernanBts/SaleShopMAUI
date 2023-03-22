using SaleShop.Shared.DTOs;

namespace SaleShop.API.Helpers
{
	public static class QueryableExtensions
	{
		public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO paginationDTO)
		{
			return queryable
				.Skip((paginationDTO.Page - 1) * paginationDTO.ItemsNumber)
				.Take(paginationDTO.ItemsNumber);
		}
	}
}
