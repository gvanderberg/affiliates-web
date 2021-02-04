using System.Threading.Tasks;

using Affiliates.Web.Models;

namespace Affiliates.Web.Services
{
    public interface ILeadService
    {
        Task<ResultModel> SubmitAsync(LeadInputModel model);
    }
}