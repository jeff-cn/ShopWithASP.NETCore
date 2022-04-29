using ShopWithASP.NETCore.Application.Interfaces.Contexts;
using ShopWithASP.NETCore.Common;
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
        public ResultDto<ResultRegisterUserDto> Execute(RequsetRegisterUserDto _request)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(_request.FullName))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام و نام خانوادگی را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(_request.Email))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "پست الکترونیک را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(_request.Password))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد نمایید"
                    };
                }
                if (_request.Password != _request.RePasword)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"
                    };
                }
                User user = new User()
                {
                    Email = _request.Email,
                    FullName = _request.FullName,
                    Password = HashPassword.Execute(_request.Password),
                };
                
                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in _request.Roles)
                {
                    var roles = _context.Roles.Find(item.RoleId);
                    userInRoles.Add(new UserInRole
                    {
                        Role = roles,
                        RoleId = roles.RoleId,
                        User = user,
                        UserId = user.UserId,
                    });
                }
                user.UserInRoles = userInRoles;
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
            catch (Exception)
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }
        }
    }
    public class RequsetRegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePasword { get; set; }
        public List<RolesInRegisterUserDto> Roles { get; set; }
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
