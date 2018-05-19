using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuegoAdivinarNumero.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuienJuega(string idJuega)
        {
            if (idJuega == "persona")
            {
                return PartialView("_JuegoPersona");
            }
            else
            {
                return PartialView("_JuegoComputadora");
            }
        }

        public ActionResult NuevoJuego(string id)
        {
            if (id == "pc")
            {
                return PartialView("_JugarNuevoComputadora");
            }
            else
            {
                return PartialView("_JugarNuevoPersona");
            }
        }
        public string Comparar(int numPC, int numPersona)
        {
            Services.AdivinarNumeroServices Adivinar = new Services.AdivinarNumeroServices();
            string respuesta = Adivinar.Comparar(numPC, numPersona);
            return respuesta;
        }

        public ActionResult SeguirJuego(string idJuega)
        {
            if (idJuega == "Si")
            {
                return PartialView("_Index");
            }
            else
            {
                return PartialView("_Finaliza");
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}