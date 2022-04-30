using ShopWithASP.NETCore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWithASP.NETCore.Application.Services.Users.Commands.UserSatusChange
{

    public interface IUserSatusChangeService
    {
        ResultDto Execute(long UserId);
    }
}
