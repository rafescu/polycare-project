using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Pacientes {

        public Pacientes() {
            Marcacoes = new HashSet<Marcacoes>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // PK não será AutoNumber
        public int PacienteID { get; set; } // PK, por exigência da Entity Framework

        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório.")]
        [Display(Name ="Nome do Paciente")]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòùâêîôûãõäëïöüç']+((-| )(((da|de|do|das|dos )))?[A-ZÁÉÍÓÚ][a-záéíóúàèìòùâêîôûãõäëïöüç']+)*",ErrorMessage ="O {0} introduzido não é válido. Os nomes começam por letra maiúscula e não podem ser utilizados números.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name ="Data de Nascimento")]
        [DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime? DataNascimento { get; set; }


        public string Sexo { get; set; }

        

        //falta colocar seguranca neste upload
        //[DataType(DataType.Upload)]
        public string Foto { get; set; }
 
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [RegularExpression("[0-9]{9}", ErrorMessage ="Escreva 9 números...")]
        public string NIF { get; set; }

        //##################################################################
        //criar um atributo para ligar este atributo à BD de autenticacao
        //##################################################################
        //[Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Email do Paciente")]
        [EmailAddress(ErrorMessage = "O formato deste email não é valido...")]
        public string Username { get; set; }

        // um PACIENTE tem uma coleção de Marcacoes
        public virtual ICollection<Marcacoes> Marcacoes { get; set; }

    }
}