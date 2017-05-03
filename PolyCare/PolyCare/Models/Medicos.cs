using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Medicos {

        public Medicos() {
            Marcacoes = new HashSet<Marcacoes>();
            MedicoEspecialidades = new HashSet<MedicoEspecialidades>();
        }

        [Key]
        public int MedicoID { get; set; }

        public int CodMedico { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        public string Foto { get; set; }

        [ForeignKey("Especialidade")]
        public int EspecialidadeFK { get; set; }
        public virtual Especialidades Especialidade { get; set; }

        [StringLength(9)]
        public string NIF { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataEntradaClinica { get; set; }

        [Required]
        [StringLength(30)]
        public string NumCedulaProf { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataInscOrdem { get; set; }

        [StringLength(50)]
        public string Faculdade { get; set; }

        public virtual ICollection<Marcacoes> Marcacoes { get; set; }
        public virtual ICollection<MedicoEspecialidades> MedicoEspecialidades { get; set; }
    }
}