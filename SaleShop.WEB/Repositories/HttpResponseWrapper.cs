using System.Net;

namespace SaleShop.WEB.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }
        public bool Error { get; set; }
        public T? Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> GetErrorMessage()
        {
            if (Error)
            {
                return null;
            }

            var statusCode = HttpResponseMessage.StatusCode;
            if (statusCode == HttpStatusCode.NotFound)
            {
                return "Recurso no econtrado.";
            }
            else if (statusCode == HttpStatusCode.BadRequest) 
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if(statusCode == HttpStatusCode.Unauthorized)
            {
                return "Tiene que logearse para realizar esta operacion.";
            }
            else if( statusCode == HttpStatusCode.Forbidden) 
            {
                return "No tiene permisos para realizar esta operacion.";
            }

            return "Ha ocurrido un error inesperado.";
        }

    }
}
