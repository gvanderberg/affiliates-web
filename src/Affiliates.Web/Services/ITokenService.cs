using System.Threading.Tasks;

namespace Affiliates.Web.Services
{
    public interface ITokenService
    {
        string GetAccessToken();
    }
}