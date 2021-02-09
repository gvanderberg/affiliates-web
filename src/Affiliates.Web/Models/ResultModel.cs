using System.Text.Json.Serialization;

namespace Affiliates.Web.Models
{
    public class ResultModel
    {
        [JsonPropertyName("reference-number")]
        public string ReferenceNumber { get; set; }
    }
}