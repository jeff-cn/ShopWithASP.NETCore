using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWithASP.NETCore.Application.Services.Users.Queries.GetRoles;
using ShopWithASP.NETCore.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        public UsersController(IGetUsersService getUsersService, IGetRolesService getRolesService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
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
    }
}
