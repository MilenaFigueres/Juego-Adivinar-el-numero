using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JuegoAdivinarNumero.Models;
using System.Data.Entity;

namespace JuegoAdivinarNumero.Services
{
    public class AdivinarNumeroServices
    {
        public string Comparar(int numero1, int numero2)
        {
            Juego jp = new Juego();
            jp.numeroAleatorio = numero1;
            jp.numeroAdivinado = numero2;
            jp.respuesta = "";
            if (numero1 > numero2)
            {
                jp.respuesta = "Mi número es más grande";//Mi número es más grande 
            }
            else if (numero1 < numero2)
            {
                jp.respuesta = "Mi número es más chico";//Mi número es más chico
            }
            else
            {
                jp.respuesta = "Felicidades";
            }

            return jp.respuesta;
        }

        public Dictionary<string, int> busquedaBinaria(int numeroAleatorio, string tamanio, int limiteIzq, int limiteDer)
        {
            var lista = new Dictionary<string, int>();
            int numeroElegido = 0;

            if (tamanio == "grande")
            {
                limiteIzq = numeroAleatorio;
            }
            else
            {
                limiteDer = numeroAleatorio;
            }
            numeroElegido = Math.Abs((limiteDer - limiteIzq) / 2) + limiteIzq;

            lista.Add("limiteIzquierdo", limiteIzq);
            lista.Add("limiteDerecho", limiteDer);
            lista.Add("numeroElegido", numeroElegido);
            return lista;
        }

    }
}