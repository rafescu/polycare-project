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
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // PK não será AutoNumber
        public int MedicoID { get; set; } // PK, por exigência da Entity Framework

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Nome do Médico")]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòùâêîôûãõäëïöüç']+((-| )(((da|de|do|das|dos )))?[A-ZÁÉÍÓÚ][a-záéíóúàèìòùâêîôûãõäëïöüç']+)*", ErrorMessage = "O {0} introduzido não é válido. Os nomes começam por letra maiúscula e não podem ser utilizados números.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }


        //falta colocar seguranca neste upload
        //[DataType(DataType.Upload)]
        public string Foto { get; set; }

        // definição da chave forasteira (FK) que referencia a classe Especialidades
        [ForeignKey("Especialidade")]
        public int EspecialidadeFK { get; set; }
        public virtual Especialidades Especialidade { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "Escreva 9 números...")]
        public string NIF { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Data da Entrada na Clínica")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataEntradaClinica { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        //[RegularExpression("[0-9]", ErrorMessage = "Escreva apenas números de 0 a 9...")]
        public string NumCedulaProf { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Data da Inscrição na Ordem")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataInscOrdem { get; set; }

        [StringLength(50)]
        public string Faculdade { get; set; }

        //##################################################################
        //criar um atributo para ligar este atributo à BD de autenticacao
        //##################################################################
        //[Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Email do Médico")]
        [EmailAddress(ErrorMessage = "O formato deste email não é valido...")]
        public string Username { get; set; }

        public virtual ICollection<Marcacoes> Marcacoes { get; set; }
        public virtual ICollection<Atendimentos> Atendimentos { get; set; }
    }
}