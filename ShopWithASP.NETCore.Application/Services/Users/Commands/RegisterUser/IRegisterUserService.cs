using ShopWithASP.NETCore.Application.Interfaces.Contexts;
using ShopWithASP.NETCore.Common.Dto;
using ShopWithASP.NETCore.Doima.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWithASP.NETCore.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequsetRegisterUserDto _requset);
    }
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;
        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequsetRegisterUserDto _requset)
        {
            User user = new User()
            {
                Email = _requset.Email,
                FullName = _requset.FullName,

            };
            List<UserInRole> _UserInRoles = new List<UserInRole>();
            foreach (var item in _requset._roles)
            {
                var roles = _context.Roles.Find(item.RoleId);
                _UserInRoles.Add(new UserInRole
                {
                    Role = roles,
                    RoleId = roles.RoleId,
                    User = user,
                    UserId = user.UserId,
                });
            }
            user.UserInRoles = _UserInRoles;
            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResultDto<ResultRegisterUserDto>()
            {
                Data = new ResultRegisterUserDto()
                {
                    UserId = user.UserId
                },
                IsSuccess = true,
                Message = "ثبت نام کاربر انجام شد.",
            };
        }
    }
    public class RequsetRegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<RolesInRegisterUserDto> _roles { get; set; }
    }

    public class RolesInRegisterUserDto
    {
        public long RoleId { get; set; }
    }
    public class ResultRegisterUserDto
    {
        public long UserId { get; set; }
    }
}
