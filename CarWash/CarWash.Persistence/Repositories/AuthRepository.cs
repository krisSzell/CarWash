using CarWash.Persistence.Models.Accounts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Security;

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
            _userManager.AddToRole(user.Id, "Customer");

            return result;
        }

        public async Task<ApplicationUser> FindUser(string email, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(email, password);

            return user;
        }

        public ApplicationUser FindUserByUsername(string username)
        {
            ApplicationUser user = _context.Users.SingleOrDefault(u => u.UserName == username);

            return user;
        }

        public void Dispose()
        {
            _context.Dispose();
            _userManager.Dispose();
        }
    }
}
