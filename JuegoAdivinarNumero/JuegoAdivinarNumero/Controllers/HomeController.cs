using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JuegoAdivinarNumero.Models;

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
                Session["limiteIzquierdo"] = 1; Session["limiteDerecho"] = 100;
                return PartialView("_JuegoComputadora");
            }
        }

        //public ActionResult NuevoJuego(string id)
        //{
        //    if (id == "pc")
        //    {
        //        return PartialView("_JugarNuevoComputadora");
        //    }
        //    else
        //    {
        //        return PartialView("_JugarNuevoPersona");
        //    }
        //}
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
                return PartialView("Index");
            }
            else
            {
                return PartialView("_Finaliza");
            }
        }

        public int busquedaBinaria(int numeroAleatorio, string tamanio)
        {
            Services.AdivinarNumeroServices Adivinar = new Services.AdivinarNumeroServices();
            var limiteIzquierdo = (int)Session["limiteIzquierdo"];
            var limiteDerecho = (int)Session["limiteDerecho"];
            var respuesta = Adivinar.busquedaBinaria(numeroAleatorio, tamanio, limiteIzquierdo, limiteDerecho);
            Session["limiteIzquierdo"] = respuesta["limiteIzquierdo"];
            Session["limiteDerecho"] = respuesta["limiteDerecho"];
            return respuesta["numeroElegido"];
        }

        public ActionResult Editar(int id)
        {
            Juego modelo = new Juego();
            return PartialView(modelo);
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