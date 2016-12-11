using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Net;

namespace BookStore.Utils.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        //Retorna um cabeçalho, é padrão, caso venha a ser negada eu envio no Header do reponse essas informaçãoes, 
        //para o usuario saber qual é a autenticação que estou esperando
        private const string BasicAuthResponseHeader = "WWW-Autenticate";
        private const string BasicAuthResponseHeaderValue = "Basic";

        //Método para autorização
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //Recupera a informação que vem do header da request da API
            var authValue = actionContext.Request.Headers.Authorization;

            //Vefica se é diferente de null, se passou valor no header e se o tipo de autorização é basic
            if (authValue != null && !String.IsNullOrEmpty(authValue.Parameter) && authValue.Scheme == BasicAuthResponseHeaderValue)
            {
                //Verifica o hash em base 64 pega a string decondifica e da um split em dois pontos para pegar o usuario e a senha
                string[] credentials = Encoding.ASCII.GetString(Convert.FromBase64String(authValue.Parameter)).Split(new[] { ':' });
            }
            else//Caso não tenha dado certo, retorna 401 unauthorized
            {
                actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }
            base.OnAuthorization(actionContext);
        }
    }
}
