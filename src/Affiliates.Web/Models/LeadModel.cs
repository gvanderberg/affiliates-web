using System.Text.Json.Serialization;

namespace Affiliates.Web.Models
{
    public class LeadModel
    {
        [JsonPropertyName("phone-number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("reference-number")]
        public string ReferenceNumber { get; set; }

        [JsonPropertyName("contact-person")]
        public PersonModel Person { get; set; } = new PersonModel();
    }
}