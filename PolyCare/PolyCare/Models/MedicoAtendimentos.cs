using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class MedicoAtendimentos {

        [Key]
        public int MedicoAtendimentosID { get; set; }
        [ForeignKey("Medico")]
        public int MedicoFK { get; set; }
        public virtual Medicos Medico { get; set; }


        [ForeignKey("Atendimento")]
        public int AtendimentoFK { get; set; }
        public virtual Atendimentos Atendimento { get; set; }
    }
}