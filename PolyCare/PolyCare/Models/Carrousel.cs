using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Carrousel {
        //id da imagem
        public int ID { get; set; }

        //id do Funcionário que insere a imagem
        public string IdFuncionario { get; set; }


        //data e hora da inserção da imagem
        [Display(Name = "Data|Hora de Inserção")]
        public DateTime TimeStamp { get; set; }

        //título da imagem
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
        [Display(Name = "Título")]
        [RegularExpression("[A-ZÁÉÍÓÚ][a-záéíóúàèìòùâêîôûãõäëïöüç']+((-| )(((da|de|do|das|dos )))?[A-ZÁÉÍÓÚ][a-záéíóúàèìòùâêîôûãõäëïöüç']+)*", ErrorMessage = "O {0} introduzido não é válido.")]
        public string Title { get; set; }

        //endereço da imagem
        [Display(Name = "Nome da Imagem")]
        public string ImgSource { get; set; }
    }
}