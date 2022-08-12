using Pear.Africa.Assessment.Common.Identity.Account;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pear.Africa.Assessment.Client.Infrastructure.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task Logout();
        Task<string> RefreshToken();
    }
}
