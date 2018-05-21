using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testeBuscaMarvel.Models
{
    public class Personagem
    {
        [Key]
        public int idPersonagem { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Historias { get; set; }
        public string Imagem { get; set; }
    }
}