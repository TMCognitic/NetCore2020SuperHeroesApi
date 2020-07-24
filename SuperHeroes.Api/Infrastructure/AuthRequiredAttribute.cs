using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SuperHeroes.Api.Infrastructure
{
    public class AuthRequiredAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            actionContext.Request.Headers.TryGetValues("Authorization", out IEnumerable<string> authorisations);

            string token = authorisations?.SingleOrDefault(t => t.StartsWith("Bearer "));

            if (token is null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                IDictionary<string, string> keyValuePairs = ResourceLocator.Instance.TokenService.DecodeToken(token, new string[] { "Id" });

                if (keyValuePairs is null)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                else if (keyValuePairs.Count == 0)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
                else
                {
                    actionContext.RequestContext.RouteData.Values.Add("userId", int.Parse(keyValuePairs["Id"]));
                }
            }
        }
    }
}