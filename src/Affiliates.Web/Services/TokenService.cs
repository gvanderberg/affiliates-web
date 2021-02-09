using Microsoft.Extensions.Logging;

namespace Affiliates.Web.Services
{
    public class TokenService : ITokenService
    {
        private readonly ILogger<TokenService> _logger;

        private readonly LeadApiSettings _settings;

        public TokenService(ILogger<TokenService> logger, LeadApiSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public string GetAccessToken()
        {
            return _settings.ApiKey;
        }
    }
}