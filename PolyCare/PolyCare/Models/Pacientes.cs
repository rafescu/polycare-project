using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Pacientes {

        public Pacientes() {
            Marcacoes = new HashSet<Marcacoes>();
        }

        [Key]
        public int PacienteID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        
        public string Sexo { get; set; }
        
        public string Foto { get; set; }
        [Required]
        [StringLength(13)]
        public string Telemovel { get; set; }
        [Required]
        [StringLength(9)]
        public string NIF { get; set; }

        // um PACIENTE tem uma coleção de Marcacoes
        public virtual ICollection<Marcacoes> Marcacoes { get; set; }

    }
}