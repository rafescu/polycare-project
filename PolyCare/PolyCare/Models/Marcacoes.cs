using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Marcacoes {
        [Key]
        public int MarcacaoID { get; set; } // PK, por exigência da Entity Framework
        [Required]
        public int CodMarcacao { get; set; }

        [Column(TypeName = "date")] //só regista 'datas', não 'horas'
        public DateTime DataMarcacoes { get; set; }

        // definição da chave forasteira (FK) que referencia a classe Medicos
        [ForeignKey("Medico")]
        public int MedicoFK { get; set; }
        public virtual Medicos Medico { get; set; }


        [ForeignKey("Paciente")]
        public int PacienteFK { get; set; }
        public virtual Pacientes Paciente { get; set; }
    }
}