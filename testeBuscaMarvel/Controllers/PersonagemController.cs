using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testeBuscaMarvel.Models;
using testeBuscaMarvel.Suporte;

namespace testeBuscaMarvel.Controllers
{
    public class PersonagemController : Controller
    {
        private testeBuscaMarvelContext db = new testeBuscaMarvelContext();

        // GET: Personagem
        public ActionResult Index(string searchString)
        {
            RootObject personagemBuscado = new RootObject();
            if (!string.IsNullOrEmpty(searchString))
            {
                string busca = Busca.BuscaPersonagem(searchString);

                personagemBuscado = JsonConvert.DeserializeObject<RootObject>(busca);

                foreach (var item in personagemBuscado.data.results)
                {
                    item.thumbnail.path += "/portrait_xlarge.jpg";
                    foreach (var historias in item.comics.items)
                    {
                        item.historias += historias.name + System.Environment.NewLine;
                    }
                }

                HistoricoBusca novaBusca = new HistoricoBusca();
                novaBusca.personagemBuscado = searchString;
                novaBusca.HoraDaBusca = DateTime.Now;
                db.HistoricoBuscas.Add(novaBusca);
                db.SaveChanges();
                return View(personagemBuscado.data.results.ToList());
            }


            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
