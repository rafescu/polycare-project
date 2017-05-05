namespace PolyCare.Migrations
{
    using PolyCare.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PolyCare.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PolyCare.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            // ############################################################################################
            // adiciona PACIENTES
            var pacientes = new List<Pacientes> {
   new Pacientes  {PacienteID=1, Nome = "Pedro Gonkas", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", NIF="123456789"},
   new Pacientes  {PacienteID=2, Nome = "Maria Leal", DataNascimento=new DateTime(2015,2,8), Sexo="F", Foto="avatar.png", NIF="123456789"},
   new Pacientes  {PacienteID=3, Nome = "Uri Kol", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", NIF="123456789"},
   new Pacientes  {PacienteID=4, Nome = "Keith Num", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", NIF="123456789"},
   new Pacientes  {PacienteID=5, Nome = "Francisco Alves", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", NIF="123456789"},
   new Pacientes  {PacienteID=6, Nome = "Nuno Pedro", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", NIF="123456789"},
   new Pacientes  {PacienteID=7, Nome = "Rafael Hugo", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", NIF="123456789"},
   new Pacientes  {PacienteID=8, Nome = "Joana Maira", DataNascimento=new DateTime(2015,2,8), Sexo="F", Foto="avatar.png", NIF="123456789"},
   new Pacientes  {PacienteID=9, Nome = "Francisca Hugo", DataNascimento=new DateTime(2015,2,8), Sexo="F", Foto="avatar.png", NIF="123456789"},
   new Pacientes  {PacienteID=10, Nome = "David Tudora", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", NIF="123456789"}

};

            pacientes.ForEach(aa => context.Pacientes.AddOrUpdate(a => a.Nome, aa));
            context.SaveChanges();


            // ############################################################################################
            // adiciona ESPECIALIDADES
            var especialidades = new List<Especialidades> {
   new Especialidades  {EspecialidadeID=1, Designacao="Dentista"},
   new Especialidades  {EspecialidadeID=2, Designacao="Acunputura"},
   new Especialidades  {EspecialidadeID=3, Designacao="Fisioterapeuta"},
   new Especialidades  {EspecialidadeID=4, Designacao="Otorrinolaringologista"},
   new Especialidades  {EspecialidadeID=5, Designacao="Farmaceutico"},
   new Especialidades  {EspecialidadeID=6, Designacao="Enfermeiro"},
   new Especialidades  {EspecialidadeID=7, Designacao="Massagista"},
   new Especialidades  {EspecialidadeID=8, Designacao="Psicologo"},
   new Especialidades  {EspecialidadeID=9, Designacao="Pediatra"},
   new Especialidades  {EspecialidadeID=10, Designacao="Psiquiatra"}

};

            especialidades.ForEach(vv => context.Especialidades.AddOrUpdate(v => v.Designacao, vv));
            context.SaveChanges();


            // ############################################################################################
            // adiciona MEDICOS
            var medicos = new List<Medicos> {
   new Medicos  {MedicoID=1, Nome = "Maria Pinto", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=8, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Porto"},
   new Medicos  {MedicoID=2, Nome = "Pedro Delgado", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=3, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Porto"},
   new Medicos  {MedicoID=3, Nome = "Lopes Sousa", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=5, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Porto"},
   new Medicos  {MedicoID=4, Nome = "Daniel Tudor", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=6, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Porto"},
   new Medicos  {MedicoID=5, Nome = "Maria Ana", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Porto"},
   new Medicos  {MedicoID=6, Nome = "Rute Marlene", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Lisboa"},
   new Medicos  {MedicoID=7, Nome = "Carlos Saldenha", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=2, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Lisboa"},
   new Medicos  {MedicoID=8, Nome = "Miguel Filipe", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=3, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Lisboa"},
   new Medicos  {MedicoID=9, Nome = "Mariana Huth", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Lisboa"},
   new Medicos  {MedicoID=10, Nome = "Marta Huth", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=2, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Lisboa"}
};

            medicos.ForEach(xx => context.Medicos.AddOrUpdate(x => x.Nome, xx));
            context.SaveChanges();

            


        }
    }
}
