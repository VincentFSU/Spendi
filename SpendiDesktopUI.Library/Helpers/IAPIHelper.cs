using SpendiDesktopUI.Models;
using System.Threading.Tasks;

namespace SpendiDesktopUI.Library.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);

        Task GetLoggedInUserInfo(string token);
    }
}