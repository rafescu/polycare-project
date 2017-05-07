using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class MedicoAtendimentos {

        [Key]
        public int MedicoAtendimentosID { get; set; } // PK, por exigência da Entity Framework

        // definição da chave forasteira (FK) que referencia a classe Medicos
        [ForeignKey("Medico")]
        public int MedicoFK { get; set; }
        public virtual Medicos Medico { get; set; }

        // definição da chave forasteira (FK) que referencia a classe Atendimento
        [ForeignKey("Atendimento")]
        public int AtendimentoFK { get; set; }
        public virtual Atendimentos Atendimento { get; set; }
    }
}