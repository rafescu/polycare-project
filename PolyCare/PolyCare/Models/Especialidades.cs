using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Especialidades {

        public Especialidades() {
            MedicoEspecialidades = new HashSet<MedicoEspecialidades>();
        }

        [Key]
        public int EspecialidadeID { get; set; }

        public string Designacao { get; set; }

        // uma ESPECIALIDADE tem uma coleção de Medicos
        public virtual ICollection<MedicoEspecialidades> MedicoEspecialidades { get; set; }
    }
}