using Microsoft.AspNetCore.Mvc;
using ShopWithASP.NETCore.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        public UsersController(IGetUsersService getUsersService)
        {
            _getUsersService = getUsersService;
        }

        [Area("Admin")]
        public IActionResult Index(string SearchKey, int Page)
        {
            return View(_getUsersService.Execute(new RequsetGetUserDto
            {
                SearchKey = SearchKey,
                Page = Page,
            }));
        }
    }
}
