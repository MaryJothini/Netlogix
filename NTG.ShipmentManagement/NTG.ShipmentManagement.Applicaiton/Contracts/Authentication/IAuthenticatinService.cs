using NTG.ShipmentManagement.Applicaiton.Models;
using NTG.ShipmentManagement.Applicaiton.UserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTG.ShipmentManagement.Applicaiton.Contracts.Authentication
{
    public interface IAuthenticatinService
    {
        Task<LoginResponse> Login(UserLoginDto login);
    }
}
