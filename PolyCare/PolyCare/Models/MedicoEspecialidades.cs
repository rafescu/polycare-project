using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class MedicoEspecialidades {
        [Key]
        public int MedicoEspecialidadesID { get; set; } // PK, por exigência da Entity Framework

        // definição da chave forasteira (FK) que referencia a classe Medicos
        [ForeignKey("Medico")]
        public int MedicoFK { get; set; }
        public Medicos Medico { get; set; }
        
        // definição da chave forasteira (FK) que referencia a classe Especialidades
        [ForeignKey("Especialidade")]
        public int EspecialidadeFK { get; set; }
        public Especialidades Especialidade { get; set; }
        
    }
}