using Microsoft.AspNetCore.Mvc;
using jcarrollonlinev4.backend.Models;

namespace jcarrollonlinev4.backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly ILogger<UserInfoController> _logger;

        public UserInfoController(ILogger<UserInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserInfo")]
        public UserInfo Get()
        {
            //WindowsAccountType.
            return new UserInfo() { user_name = "John", user_id = 1, user_post_count = 6, user_followers_count = 7, user_following_count = 8 };
        }
    }
}