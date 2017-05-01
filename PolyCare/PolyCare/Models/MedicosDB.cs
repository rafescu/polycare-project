using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class MedicosDB : DbContext {

        //representar as tabelas a criar na Base de Dados

        public virtual DbSet<Pacientes> Pacientes { get; set; }

        //especificar onde será criada a Base de Dados
        public MedicosDB() : base("LocalizacaoDaBD") {

        }
    }
}