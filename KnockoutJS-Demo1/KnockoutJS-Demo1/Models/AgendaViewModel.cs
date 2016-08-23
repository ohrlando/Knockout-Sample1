using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutJS_Demo1.Models
{
    public class AgendaViewModel
    {
        public string AgendaNome { get; set; }
        public List<AgendaEvento> Eventos { get; set; } = new List<AgendaEvento>();
    }

    public class AgendaEvento
    {
        public DateTime Data { get; set; }
        public string EventoNome { get; set; }
        public string Obs { get; set; }
        public bool estaAtivo { get; set; } = true;
    }
}