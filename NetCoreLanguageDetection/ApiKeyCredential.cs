using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace NetCoreLanguageDetection
{
    public class ApiKeyCredential : ServiceClientCredentials
    {
         readonly string apiKey;

        public ApiKeyCredential(string apiKeyParam)
        {
            apiKey = apiKeyParam;
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            // client isteğinin Header bilgilerine API key değerimizi ekliyoruz.
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}