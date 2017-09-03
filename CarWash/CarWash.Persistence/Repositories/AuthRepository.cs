using CarWash.Persistence.Models.Accounts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace CarWash.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository, IDisposable
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }


        public async Task<IdentityResult> RegisterUser(RegisterModel registerModel)
        {
            var user = new ApplicationUser
            {
                UserName = registerModel.Email,
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
