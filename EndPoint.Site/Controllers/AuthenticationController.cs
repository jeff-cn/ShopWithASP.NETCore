using Microsoft.AspNetCore.Mvc;
using ShopWithASP.NETCore.Application.Services.Users.Commands.RegisterUser;

namespace EndPoint.Site.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRegisterUserService _registerUserService;
        //private readonly IUserLoginService _userLoginService;
        public AuthenticationController(IRegisterUserService registerUserService/*, 
            IUserLoginService userLoginService*/)
        {
            _registerUserService = registerUserService;
            //_userLoginService = userLoginService;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
    }
}
