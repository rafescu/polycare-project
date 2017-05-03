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
        public int ID { get; set; }

        public int CodPaciente { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public string Foto { get; set; }

        public string Telemovel { get; set; }

        // um PACIENTE tem uma coleção de Marcacoes
        public virtual ICollection<Marcacoes> Marcacoes { get; set; }

    }
}