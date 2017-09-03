using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Persistence.Models.Accounts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarWash.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository, IDisposable
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
        }


        public async Task<IdentityResult> RegisterUser(RegisterModel registerModel)
        {
            var user = new ApplicationUser
            {
                Email = registerModel.Email,
                Name = registerModel.Name,
                Surename = registerModel.Surename
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
            _userManager.Dispose();
        }
    }
}
