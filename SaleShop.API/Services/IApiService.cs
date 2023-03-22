using SaleShop.Shared.Responses;

namespace SaleShop.API.Services
{
	public interface IApiService
	{
		Task<Response> GetListAsync<T>(string servicePrefix, string controller);
	}
}
