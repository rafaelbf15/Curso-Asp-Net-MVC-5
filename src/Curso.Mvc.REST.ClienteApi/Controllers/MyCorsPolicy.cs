using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace Curso.Mvc.REST.ClienteApi.Controllers
{
    public class MyCorsPolicy : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;
        public MyCorsPolicy()
        {
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            // Add allowed origins.
            _policy.Origins.Add("http://myclient.azurewebsites.net");
            _policy.Origins.Add("http://www.contoso.com");
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}