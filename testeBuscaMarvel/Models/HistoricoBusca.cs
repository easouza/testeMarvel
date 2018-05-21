using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testeBuscaMarvel.Models
{
    public class HistoricoBusca
    {
        [Key]
        public int IdHistoricoBusca { get; set; }
        public string personagemBuscado { get; set; }
        public DateTime HoraDaBusca { get; set; }
    }
}