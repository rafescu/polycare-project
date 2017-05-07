namespace PolyCare.Migrations {
    using PolyCare.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PolyCare.Models.ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PolyCare.Models.ApplicationDbContext context) {
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


            // ############################################################################################
            // adiciona Marcacoes
            var marcacoes = new List<Marcacoes> {
   new Marcacoes  {MarcacaoID=1, CodMarcacao = 1234, DataMarcacoes=new DateTime(2013,1,2), MedicoFK=2, PacienteFK=8},
   new Marcacoes  {MarcacaoID=2, CodMarcacao = 2222, DataMarcacoes=new DateTime(2014,2,2), MedicoFK=1, PacienteFK=9},
   new Marcacoes  {MarcacaoID=3, CodMarcacao = 3333, DataMarcacoes=new DateTime(2014,3,1), MedicoFK=8, PacienteFK=9},
   new Marcacoes  {MarcacaoID=4, CodMarcacao = 1122, DataMarcacoes=new DateTime(2015,3,2), MedicoFK=9, PacienteFK=8},
   new Marcacoes  {MarcacaoID=5, CodMarcacao = 1233, DataMarcacoes=new DateTime(2015,4,2), MedicoFK=8, PacienteFK=4},
   new Marcacoes  {MarcacaoID=6, CodMarcacao = 4444, DataMarcacoes=new DateTime(2015,6,11), MedicoFK=3, PacienteFK=3},
   new Marcacoes  {MarcacaoID=7, CodMarcacao = 5555, DataMarcacoes=new DateTime(2016,7,12), MedicoFK=4, PacienteFK=3},
   new Marcacoes  {MarcacaoID=8, CodMarcacao = 3323, DataMarcacoes=new DateTime(2016,8,14), MedicoFK=5, PacienteFK=2},
   new Marcacoes  {MarcacaoID=9, CodMarcacao = 3457, DataMarcacoes=new DateTime(2016,9,21), MedicoFK=5, PacienteFK=1},
   new Marcacoes  {MarcacaoID=10, CodMarcacao = 8968, DataMarcacoes=new DateTime(2016,10,22), MedicoFK=6, PacienteFK=5}
};

            marcacoes.ForEach(yy => context.Marcacoes.AddOrUpdate(y => y.MarcacaoID, yy));
            context.SaveChanges();


            // ############################################################################################
            // adiciona Atendimentos
            var atendimentos = new List<Atendimentos> {
   new Atendimentos  {AtendimentoID=1, DataAtivacao = new DateTime(2013,1,2), DiaSemana="segunda", Inicio=new DateTime(2013,1,3), Fim=new DateTime(2013,1,3)},
   new Atendimentos  {AtendimentoID=2, DataAtivacao = new DateTime(2013,1,3), DiaSemana="terca", Inicio=new DateTime(2013,1,4), Fim=new DateTime(2013,1,4)},
   new Atendimentos  {AtendimentoID=3, DataAtivacao = new DateTime(2013,1,4), DiaSemana="quarta", Inicio=new DateTime(2013,1,5), Fim=new DateTime(2013,1,5)},
   new Atendimentos  {AtendimentoID=4, DataAtivacao = new DateTime(2013,1,5), DiaSemana="quinta", Inicio=new DateTime(2013,1,6), Fim=new DateTime(2013,1,6)},
   new Atendimentos  {AtendimentoID=5, DataAtivacao = new DateTime(2013,1,6), DiaSemana="sexta", Inicio=new DateTime(2013,1,7), Fim=new DateTime(2013,1,7)},
   new Atendimentos  {AtendimentoID=6, DataAtivacao = new DateTime(2013,1,7), DiaSemana="sábado", Inicio=new DateTime(2013,1,8), Fim=new DateTime(2013,1,8)},
   new Atendimentos  {AtendimentoID=7, DataAtivacao = new DateTime(2013,1,8), DiaSemana="domingo", Inicio=new DateTime(2013,1,9), Fim=new DateTime(2013,1,9)},
   new Atendimentos  {AtendimentoID=8, DataAtivacao = new DateTime(2013,1,9), DiaSemana="segunda", Inicio=new DateTime(2013,1,10), Fim=new DateTime(2013,1,10)},
   new Atendimentos  {AtendimentoID=9, DataAtivacao = new DateTime(2013,1,10), DiaSemana="terca", Inicio=new DateTime(2013,1,11), Fim=new DateTime(2013,1,11)},
   new Atendimentos  {AtendimentoID=10, DataAtivacao = new DateTime(2013,1,11), DiaSemana="quarta", Inicio=new DateTime(2013,1,12), Fim=new DateTime(2013,1,12)}
};

            atendimentos.ForEach(zz => context.Atendimentos.AddOrUpdate(z => z.AtendimentoID, zz));
            context.SaveChanges();


            // ############################################################################################
            // adiciona MedicoAtendimentos
            var medicoAten = new List<MedicoAtendimentos> {
   new MedicoAtendimentos  {MedicoAtendimentosID=1, MedicoFK = 3, AtendimentoFK=1},
   new MedicoAtendimentos  {MedicoAtendimentosID=2, MedicoFK = 4, AtendimentoFK=2},
   new MedicoAtendimentos  {MedicoAtendimentosID=3, MedicoFK = 3, AtendimentoFK=3},
   new MedicoAtendimentos  {MedicoAtendimentosID=4, MedicoFK = 2, AtendimentoFK=4},
   new MedicoAtendimentos  {MedicoAtendimentosID=5, MedicoFK = 5, AtendimentoFK=5},
   new MedicoAtendimentos  {MedicoAtendimentosID=6, MedicoFK = 8, AtendimentoFK=6},
   new MedicoAtendimentos  {MedicoAtendimentosID=7, MedicoFK = 8, AtendimentoFK=7},
   new MedicoAtendimentos  {MedicoAtendimentosID=8, MedicoFK = 7, AtendimentoFK=8},
   new MedicoAtendimentos  {MedicoAtendimentosID=9, MedicoFK = 7, AtendimentoFK=9},
   new MedicoAtendimentos  {MedicoAtendimentosID=10, MedicoFK = 1, AtendimentoFK=10}
};

            medicoAten.ForEach(yy => context.MedicoAtendimentos.AddOrUpdate(y => y.MedicoAtendimentosID, yy));
            context.SaveChanges();




        }
    }
}
