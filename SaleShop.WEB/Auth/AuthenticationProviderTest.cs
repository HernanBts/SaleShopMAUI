using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SaleShop.WEB.Auth
{
	public class AuthenticationProviderTest : AuthenticationStateProvider
	{
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var adminUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Hernan"),
                new Claim("LastName", "bts"),
                new Claim(ClaimTypes.Name, "hernan.bts@gmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(adminUser)));
        }
    }

}
