using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWithASP.NETCore.Application.Services.Users.Commands.RegisterUser;
using ShopWithASP.NETCore.Application.Services.Users.Queries.GetRoles;
using ShopWithASP.NETCore.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        public UsersController(IGetUsersService getUsersService, IGetRolesService getRolesService,
            IRegisterUserService registerUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
        }

        public IActionResult Index(string SearchKey, int Page)
        {
            return View(_getUsersService.Execute(new RequsetGetUserDto
            {
                SearchKey = SearchKey,
                Page = Page,
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "RoleId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string FullName, string Email, long RoleId, string Password, string RePassword)
        {
            var _result = _registerUserService.Execute(new RequsetRegisterUserDto
            {
                FullName = FullName,
                Email = Email,
                Roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto
                    {
                        RoleId = RoleId
                    }
                },
                Password = Password,
                RePasword = RePassword
            });
            return Json(_result);
        }
    }
}
