using Affiliates.Web.Models;

namespace Affiliates.Web
{
    public static class LeadInputModelExtensions
    {
        public static LeadModel ToLead(this LeadInputModel model)
        {
            var lead = new LeadModel
            {
                PhoneNumber = model.ContactNumber,
                Person =
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                }
            };

            return lead;
        }
    }
}