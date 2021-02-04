using System.Text.Json;

using Affiliates.Web.Models;

namespace Affiliates.Web.Extensions
{
    public static class LeadModelExtensions
    {
        public static string ToJson(this LeadModel model)
        {
            var json = JsonSerializer.Serialize(model);

            return json;
        }
    }
}