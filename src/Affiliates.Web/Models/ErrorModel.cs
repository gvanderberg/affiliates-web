using System.Text.Json.Serialization;

namespace Affiliates.Web.Models
{
    public class ErrorModel
    {
        [JsonPropertyName("errors")]
        public dynamic Errors { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}