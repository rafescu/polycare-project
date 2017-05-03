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
   new Pacientes  {ID=1, CodPaciente=1 , Username="", Password="x", Nome = "Pedro Gonkas", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", Telemovel="123456789"},
   new Pacientes  {ID=2, CodPaciente=2 , Username="", Password="x", Nome = "Maria Leal", DataNascimento=new DateTime(2015,2,8), Sexo="F", Foto="avatar.png", Telemovel="123456789"},
   new Pacientes  {ID=3, CodPaciente=3 , Username="", Password="x", Nome = "Uri Kol", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", Telemovel="123456789"},
   new Pacientes  {ID=4, CodPaciente=4 , Username="", Password="x", Nome = "Keith Num", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", Telemovel="123456789"},
   new Pacientes  {ID=5, CodPaciente=5 , Username="", Password="x", Nome = "Francisco Alves", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", Telemovel="123456789"},
   new Pacientes  {ID=6, CodPaciente=6 , Username="", Password="x", Nome = "Nuno Pedro", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", Telemovel="123456789"},
   new Pacientes  {ID=7, CodPaciente=7 , Username="", Password="x", Nome = "Rafael Hugo", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", Telemovel="123456789"},
   new Pacientes  {ID=8, CodPaciente=8 , Username="", Password="x", Nome = "Joana Maira", DataNascimento=new DateTime(2015,2,8), Sexo="F", Foto="avatar.png", Telemovel="123456789"},
   new Pacientes  {ID=9, CodPaciente=9 , Username="", Password="x", Nome = "Francisca Hugo", DataNascimento=new DateTime(2015,2,8), Sexo="F", Foto="avatar.png", Telemovel="123456789"},
   new Pacientes  {ID=10, CodPaciente=10 , Username="", Password="x", Nome = "David Tudora", DataNascimento=new DateTime(2015,2,8), Sexo="M", Foto="avatar.png", Telemovel="123456789"}};



        pacientes.ForEach(aa => context.Pacientes.AddOrUpdate(a => a.Nome,aa));
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
   new Medicos  {MedicoID=1, CodMedico=1, Username="User", Password="x", Nome = "Maria Pinto", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Porto"},
   new Medicos  {MedicoID=2, CodMedico=2, Username="User", Password="x", Nome = "Pedro Delgado", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Porto"},
   new Medicos  {MedicoID=3, CodMedico=3, Username="User", Password="x", Nome = "Lopes Sousa", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Porto"},
   new Medicos  {MedicoID=4, CodMedico=4, Username="User", Password="x", Nome = "Daniel Tudor", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Porto"},
   new Medicos  {MedicoID=5, CodMedico=5, Username="User", Password="x", Nome = "Maria Ana", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Porto"},
   new Medicos  {MedicoID=6, CodMedico=6, Username="User", Password="x", Nome = "Rute Marlene", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Lisboa"},
   new Medicos  {MedicoID=7, CodMedico=7, Username="User", Password="x", Nome = "Carlos Saldenha", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Lisboa"},
   new Medicos  {MedicoID=8, CodMedico=8, Username="User", Password="x", Nome = "Miguel Filipe", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Lisboa"},
   new Medicos  {MedicoID=9, CodMedico=9, Username="User", Password="x", Nome = "Mariana Huth", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Lisboa"},
   new Medicos  {MedicoID=10, CodMedico=10, Username="User", Password="x", Nome = "Marta Huth", DataNascimento=new DateTime(2015,2,8), Foto="avatar.png", EspecialidadeFK=1, NIF="123456789", DataEntradaClinica=new DateTime(2015,2,8), NumCedulaProf="1234", DataInscOrdem=new DateTime(2015,2,8), Faculdade="Lisboa"}

};

        medicos.ForEach(vv => context.Medicos.AddOrUpdate(v => v.Nome,vv));
context.SaveChanges();
        }
    }
}
