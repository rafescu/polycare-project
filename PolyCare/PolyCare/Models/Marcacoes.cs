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

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório.")]
        [Display(Name = "Data da Consulta")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataMarcacoes { get; set; } //só regista 'datas', não 'horas'

        // definição da chave forasteira (FK) que referencia a classe Medicos
        [ForeignKey("Medico")]
        public int MedicoFK { get; set; }
        public virtual Medicos Medico { get; set; }

        // definição da chave forasteira (FK) que referencia a classe Pacientes
        [ForeignKey("Paciente")]
        public int PacienteFK { get; set; }
        public virtual Pacientes Paciente { get; set; }
    }
}