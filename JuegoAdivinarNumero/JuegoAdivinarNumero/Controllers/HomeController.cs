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

        public ActionResult QuienJuega(string idJuega)//Método que redirecciona a la página correspondiente, ya sea una persona o la computadora la que adivina
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
        public string Comparar(int numPC, int numPersona)//Método que realiza la comparación entre el número aleatorio seleccionado por la pc y el número que la persona piensa
        {
            Services.AdivinarNumeroServices Adivinar = new Services.AdivinarNumeroServices();
            string respuesta = Adivinar.Comparar(numPC, numPersona);
            return respuesta;
        }

        public ActionResult SeguirJuego(string idJuega)//Método que redirecciona al Inicio o Finaliza, dependiendo si el usuario quiere seguir jugando o no
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

        public int busquedaBinaria(int numeroAleatorio, string tamanio)//Método que realiza la búsqueda binaria cada vez que el usuario le dice que su número es más < o más > que el adivinado
        {
            Services.AdivinarNumeroServices Adivinar = new Services.AdivinarNumeroServices();
            var limiteIzquierdo = (int)Session["limiteIzquierdo"];
            var limiteDerecho = (int)Session["limiteDerecho"];
            var respuesta = Adivinar.busquedaBinaria(numeroAleatorio, tamanio, limiteIzquierdo, limiteDerecho);
            Session["limiteIzquierdo"] = respuesta["limiteIzquierdo"];
            Session["limiteDerecho"] = respuesta["limiteDerecho"];
            return respuesta["numeroElegido"];
        }
        public ActionResult About()//Metodo que redirecciona a la explicación del juego
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}