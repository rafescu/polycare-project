using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Especialidades {

        public Especialidades() {
            
        }

        [Key]
        public int EspecialidadeID { get; set; } // PK, por exigência da Entity Framework

        [Required]
        [StringLength(55)]
        [Display(Name = "Especialidade")]
        public string Designacao { get; set; } //nome da especialidade

        
    }
}