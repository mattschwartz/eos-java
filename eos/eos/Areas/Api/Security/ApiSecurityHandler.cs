using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using eos.Models.Data;

namespace eos.Areas.Api.Security
{
    public class ApiSecurityHandler : DelegatingHandler
    {
        public ApiSecurityHandler(HttpConfiguration httpConfiguration)
        {
            InnerHandler = new HttpControllerDispatcher(httpConfiguration);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var apiKey = (request.Headers.All(t => t.Key != "ApiKey"))
                ? null
                : request.Headers.GetValues("ApiKey").First();

            if (String.IsNullOrEmpty(apiKey)) {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Please provide an Api Key.")
                };

                var tsc = new TaskCompletionSource<HttpResponseMessage>();

                tsc.SetResult(response);

                return tsc.Task;
            }

            // Authorize  Api Key here
            try {
                using (var context = new DataContext()) {
                    var account = context.Users.FirstOrDefault(t => t.ApiKey == apiKey);

                    if (account == null) {
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    }

                    if (String.IsNullOrEmpty(account.Id)) {
                        var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                        {
                            Content = new StringContent("Api authorization denied.")
                        };

                        var tsc = new TaskCompletionSource<HttpResponseMessage>();

                        tsc.SetResult(response);

                        return tsc.Task;
                    }
                } 
            } catch (Exception) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}