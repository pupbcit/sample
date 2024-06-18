
using AccountManagementServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AccountManagement.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        UserGetServices _userGetServices;

        public UserController()
        {
            _userGetServices = new UserGetServices();
        }

        [HttpGet]
        public IEnumerable<AccountManagement.API.User> GetUsers()
        {
            var activeusers = _userGetServices.GetUsersByStatus(1);

            List<AccountManagement.API.User> users = new List<User>();

            foreach (var item in activeusers)
            {
                users.Add(new API.User { username = item.username, password = item.password, status = item.status });
            }

            return users;
        }
    }
}
