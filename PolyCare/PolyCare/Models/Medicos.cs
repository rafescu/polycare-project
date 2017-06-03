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
            Atendimentos=new HashSet<Atendimentos>();
        }

        [Key]
        public int MedicoID { get; set; } // PK, por exigência da Entity Framework

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        public string Foto { get; set; }

        // definição da chave forasteira (FK) que referencia a classe Especialidades
        [ForeignKey("Especialidade")]
        public int EspecialidadeFK { get; set; }
        public virtual Especialidades Especialidade { get; set; }
        
        [Required]
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
        public virtual ICollection<Atendimentos> Atendimentos { get; set; }
    }
}