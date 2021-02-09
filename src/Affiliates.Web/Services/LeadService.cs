using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

using Affiliates.Web.Models;

using Microsoft.Extensions.Logging;

namespace Affiliates.Web.Services
{
    public class LeadService : ILeadService
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<LeadService> _logger;

        private readonly LeadApiSettings _settings;

        public LeadService(ILogger<LeadService> logger, HttpClient httpClient, LeadApiSettings settings)
        {
            _logger = logger;
            _httpClient = httpClient;
            _settings = settings;
        }

        private async Task<TModel> _ParseModel<TModel>(HttpContent content)
        {
            var json = await content.ReadAsStringAsync().ConfigureAwait(false);
            var model = JsonSerializer.Deserialize<TModel>(json);

            return model;
        }

        public async Task<ResultModel> SubmitAsync(LeadInputModel model)
        {
            var lead = model.ToLead();

            var response = await _httpClient.PostAsJsonAsync(_settings.PostUri, lead).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var error = await _ParseModel<ErrorModel>(response.Content).ConfigureAwait(false);

                _logger.LogError(error.Title, error);
            }

            var result = await _ParseModel<ResultModel>(response.Content).ConfigureAwait(false);

            return result;
        }
    }
}