using System.Text.Json.Serialization;

namespace Affiliates.Web.Models
{
    public class PersonModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("first-name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last-name")]
        public string LastName { get; set; }
    }
}