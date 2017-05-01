using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Pacientes {
        public int ID { get; set; }

        public int CodPaciente { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public string Foto { get; set; }
    }
}