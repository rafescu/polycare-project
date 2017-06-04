using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Owin;
using Owin;
using PolyCare.Models;

[assembly: OwinStartupAttribute(typeof(PolyCare.Startup))]
namespace PolyCare
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);

            //método para inicializar os dados na BD
            //em particular, os ROLES e Utilizadores

            iniciaApp();
        }
        /// <summary>
        /// cria, caso não existam, as Roles de suporte à aplicação: Medico, Funcionario, Administrador, Paciente;
        /// cria, nesse caso, também, um utilizador para cada role...
        /// </summary>
        private void iniciaApp() {
            
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Medico'
            if (!roleManager.RoleExists("Medico")) {
                var role = new IdentityRole();
                role.Name = "Medico";
                roleManager.Create(role);

                // criar um utilizador 'Medico'
                var user = new ApplicationUser();
                user.UserName = "medico@mail.com";
                user.Email = "medico@mail.com";
                string userPWD = "123qweASD#";
                var chkUser = userManager.Create(user, userPWD);

                //Adicionar o Utilizador à respetiva Role-Medico
                if (chkUser.Succeeded) {
                    var result1 = userManager.AddToRole(user.Id, "Medico");
                }
            }

            // Criar a role 'Funcionario'
            if (!roleManager.RoleExists("Funcionario")) {
                var role = new IdentityRole();
                role.Name = "Funcionario";
                roleManager.Create(role);

                // criar um utilizador 'Funcionario'
                var user = new ApplicationUser();
                user.UserName = "funcionario@mail.com";
                user.Email = "funcionario@mail.com";
                string userPWD = "123qweASD#";
                var chkUser = userManager.Create(user, userPWD);

                //Adicionar o Utilizador à respetiva Role-Funcionario
                if (chkUser.Succeeded) {
                    var result1 = userManager.AddToRole(user.Id, "Funcionario");
                }

            }

            // Criar a role 'Administrador'
            if (!roleManager.RoleExists("Administrador")) {
                var role = new IdentityRole();
                role.Name = "Administrador";
                roleManager.Create(role);

                // criar um utilizador 'Administrador'
                var user = new ApplicationUser();
                user.UserName = "admin@mail.com";
                user.Email = "admin@mail.com";
                string userPWD = "123qweASD#";
                var chkUser = userManager.Create(user, userPWD);

                //Adicionar o Utilizador à respetiva Role-Administrador
                if (chkUser.Succeeded) {
                    var result1 = userManager.AddToRole(user.Id, "Administrador");
                }
            }

            // Criar a role 'Paciente'
            if (!roleManager.RoleExists("Paciente")) {
                var role = new IdentityRole();
                role.Name = "Paciente";
                roleManager.Create(role);

                // criar um utilizador 'Paciente'
                var user = new ApplicationUser();
                user.UserName = "paciente@mail.com";
                user.Email = "paciente@mail.com";
                string userPWD = "123qweASD#";
                var chkUser = userManager.Create(user, userPWD);

                //Adicionar o Utilizador à respetiva Role-Paciente
                if (chkUser.Succeeded) {
                    var result1 = userManager.AddToRole(user.Id, "Paciente");
                }
            }
        }
    }
}
