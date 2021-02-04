namespace Affiliates.Web
{
    public class AppSettings
    {
        public LeadApiSettings LeadApi { get; set; }
    }

    public class LeadApiSettings
    {
        public static string SectionName = "LeadApi";

        public string BaseUri { get; set; }

        public string PostUri { get; set; }
    }
}