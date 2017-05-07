using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Atendimentos {
        public Atendimentos() {
            MedicoAtendimentos = new HashSet<MedicoAtendimentos>();
        }

        [Key]
        public int AtendimentoID { get; set; } // PK, por exigência da Entity Framework

        [Column(TypeName = "date")] //só regista 'datas', não 'horas'
        public DateTime DataAtivacao { get; set; }

        public string DiaSemana { get; set; }

        [Column(TypeName = "date")] //só regista 'datas', não 'horas'
        public DateTime Inicio { get; set; }
        [Column(TypeName = "date")] //só regista 'datas', não 'horas'
        public DateTime Fim { get; set; }


        // um ATENDIMENTO tem uma coleção de MedicoAtendimentos
        public virtual ICollection<MedicoAtendimentos> MedicoAtendimentos { get; set; }
    }
}