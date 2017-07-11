using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolyCare.Models {
    public class Carrousel {
        public int ID { get; set; }
        public string IdFuncionario { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Title { get; set; }
        public string ImgSource { get; set; }
    }
}