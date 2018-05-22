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

        /// <summary>
        /// Método que redirecciona a la página correspondiente, ya sea una persona o la computadora la que adivina
        /// </summary>
        /// <param name="idJuega"></param>
        /// <returns></returns>
        public ActionResult QuienJuega(string idJuega)
        {
            if (idJuega == "persona")
                return PartialView("_JuegoPersona");

            Session["limiteIzquierdo"] = 1; Session["limiteDerecho"] = 100;
            return PartialView("_JuegoComputadora");
        }

        /// <summary>
        /// Método que realiza la comparación entre el número aleatorio seleccionado por la pc y el número que la persona piensa
        /// </summary>
        /// <param name="numPC"></param>
        /// <param name="numPersona"></param>
        /// <returns></returns>
        public string Comparar(int numPC, int numPersona)
        {
            Services.AdivinarNumeroServices Adivinar = new Services.AdivinarNumeroServices();
            string respuesta = Adivinar.Comparar(numPC, numPersona);
            return respuesta;
        }

        /// <summary>
        /// Método que redirecciona al Inicio o Finaliza, dependiendo si el usuario quiere seguir jugando o no
        /// </summary>
        /// <param name="idJuega"></param>
        /// <returns></returns>
        public ActionResult SeguirJuego(string idJuega)
        {
            if (idJuega == "Si")
                return PartialView("Index");

            return PartialView("_Finaliza");
        }

        /// <summary>
        /// Método que realiza la búsqueda binaria cada vez que el usuario le dice que su número es más < o más > que el adivinado
        /// </summary>
        /// <param name="numeroAleatorio"></param>
        /// <param name="tamanio"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo que redirecciona a la explicación del juego
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }

    }
}