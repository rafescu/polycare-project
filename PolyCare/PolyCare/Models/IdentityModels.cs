using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PolyCare.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Marcacoes> Marcacoes { get; set; }
        public virtual DbSet<Atendimentos> Atendimentos { get; set; }
        public virtual DbSet<MedicoEspecialidades> MedicoEspecialidades { get; set; }
        public virtual DbSet<MedicoAtendimentos> MedicoAtendimentos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  // impede a EF de 'pluralizar' os nomes das tabelas
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  // força a que a chave forasteira não tenha a propriedade 'on delete cascade'
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();  // força a que a chave forasteira não tenha a propriedade 'on delete cascade'

            base.OnModelCreating(modelBuilder);
        }
    }
}