using CarWash.Persistence.Models.Accounts;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(RegisterModel registerModel);
        ApplicationUser FindUserByUsername(string username);
    }
}
