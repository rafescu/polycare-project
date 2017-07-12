using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Especialidades {

        public Especialidades() {
            ListaDeMedicos = new HashSet<Medicos>();
            ListaDeMarcacoes = new HashSet<Marcacoes>();
            Checked = false;
        }

        [Key]
        public int EspecialidadeID { get; set; } // PK, por exigência da Entity Framework

        [Required]
        [StringLength(55)]
        [Display(Name = "Especialidade")]
        public string Designacao { get; set; } //nome da especialidade

        //atributo que é excluído do mapeamento da base de dados
        [NotMapped]
        public bool Checked { get; set; }

        //#########################################################################
        public virtual ICollection<Medicos> ListaDeMedicos { get; set; }

        public virtual ICollection<Marcacoes> ListaDeMarcacoes { get; set; }
        //#########################################################################
    }

}