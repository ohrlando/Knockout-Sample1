using KnockoutJS_Demo1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockoutJS_Demo1.Controllers
{
    public class AgendaController : Controller
    {
        public AgendaViewModel Agenda {
            get {
                return Session["Agenda"] as AgendaViewModel;
            }
            set
            {
                Session["Agenda"] = value;
                if (value.Eventos.Count == 0)
                {
                    value.Eventos.Add(new AgendaEvento()
                    {
                        Data = DateTime.Now,
                        EventoNome = "Criação de eventos",
                        Obs = "Use com moderação"
                    }); 
                }
            }
        }

        [HttpPost]
        public void Save(AgendaViewModel agenda)
        {
            Agenda = agenda;
        }

        // GET: Agenda
        public ActionResult Index()
        {
            if (Agenda == null) Agenda = new AgendaViewModel();

            return View(ToJSON(Agenda) as object);
        }

        //GET: Agenda/List
        public ActionResult List()
        {
            return Index();
        }

        //GET/POST: Agenda/Create
        public ActionResult Create(AgendaViewModel agenda)
        {
            return View(Agenda);
        }

        public string ToJSON(object obj)
        {
            return JsonConvert.SerializeObject(Agenda, new JsonSerializerSettings(){ ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}