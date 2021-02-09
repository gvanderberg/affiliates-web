using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Affiliates.Web.Services
{
    public class ClientCredentialDelegatingHandler : DelegatingHandler
    {
        private readonly ITokenService _accessTokenService;

        public ClientCredentialDelegatingHandler(ITokenService accessTokenService)
        {
            _accessTokenService = accessTokenService;
        }

        public ClientCredentialDelegatingHandler(ITokenService accessTokenService, HttpMessageHandler httpMessageHandler) : base(httpMessageHandler)
        {
            _accessTokenService = accessTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _accessTokenService.GetAccessToken();

            request.Headers.Add("out-api-key", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}