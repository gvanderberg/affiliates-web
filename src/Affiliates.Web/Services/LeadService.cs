using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Affiliates.Web.Extensions;
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

        public async Task<ResultModel> SubmitAsync(LeadInputModel model)
        {
            var lead = model.ToLead();
            var json = lead.ToJson();

            var response = await _httpClient.PostAsJsonAsync(_settings.PostUri, lead).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {

            }

            return new ResultModel();
        }
    }
}