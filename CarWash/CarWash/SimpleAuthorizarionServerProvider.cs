using CarWash.Persistence;
using CarWash.Persistence.Models.Accounts;
using CarWash.Persistence.Repositories;
using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarWash
{
    public class SimpleAuthorizarionServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (AuthRepository _repo = new AuthRepository(new Persistence.ApplicationDbContext()))
            {
                ApplicationUser user = await _repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);

        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            string roleName;
            var username = context.Identity.Claims
                .Where(c => c.Type == "sub")
                .First()
                .Value;
            using (var _appContext = new ApplicationDbContext())
            {
                var user = _appContext.Users
                .SingleOrDefault(u => u.UserName == username);
                var roleId = user.Roles.FirstOrDefault().RoleId;
                var role = _appContext.Roles.SingleOrDefault(r => r.Id == roleId);
                roleName = role.Name;
            }
            
            context.AdditionalResponseParameters.Add("role", roleName);
            return base.TokenEndpointResponse(context);
        }
    }
}