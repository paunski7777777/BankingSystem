namespace YourMoney.Web.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;

    using System.Linq;
    using System.Threading.Tasks;

    using YourMoney.Common;
    using YourMoney.Data;

    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext,
           UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!dbContext.Roles.Any())
            {
                await this.SeedRoles(userManager, roleManager);
            }

            await this.next(context);
        }


        private async Task SeedRoles(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminRoleExists = await roleManager.RoleExistsAsync(GlobalConstants.AdminRoleName);
            var userRoleExist = await roleManager.RoleExistsAsync(GlobalConstants.UserRoleName);

            if (!adminRoleExists || !userRoleExist)
            {
                var adminRoleResult = await roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdminRoleName));
                var userRoleResult = await roleManager.CreateAsync(new IdentityRole(GlobalConstants.UserRoleName));
            }
        }
    }
}