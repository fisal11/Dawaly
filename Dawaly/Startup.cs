using Dawaly.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dawaly.Startup))]
namespace Dawaly
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }

        public void CreateDefaultRolesAndUsers()
        {

    var roleManager = new 
                RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
    var userManager = new 
                UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)); 
        
            IdentityRole role = new IdentityRole(); 
            if (!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Mohamed";
                user.Email = "mohamed@gmail.com";
                var chek = userManager.Create(user, "mohamed123");
                if (chek.Succeeded){

                    userManager.AddToRole(user.Id, "Admins");
                }

            }
        
        }
    }

   
}
