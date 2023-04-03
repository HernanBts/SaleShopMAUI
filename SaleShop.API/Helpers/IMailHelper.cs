using SaleShop.Shared.Responses;

namespace SaleShop.API.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }
}
