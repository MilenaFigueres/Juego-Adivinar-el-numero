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
        public string Comparar(int numero1, int numero2)//Método que compara el número de la pc (aleatorio) y el número adivinado de la persona
        {
            Juego jp = new Juego();
            jp.numeroAleatorio = numero1;
            jp.numeroAdivinado = numero2;
            jp.respuesta = "";
            if (numero1 > numero2)//Mi número (pc) es más grande 
            {
                jp.respuesta = "Mi número es más grande";
            }
            else if (numero1 < numero2)//Mi número (pc) es más chico
            {
                jp.respuesta = "Mi número es más chico";
            }
            else //Mi número (pc) es el mismo
            {
                jp.respuesta = "Felicidades";
            }

            return jp.respuesta;
        }

        public Dictionary<string, int> busquedaBinaria(int numeroAleatorio, string tamanio, int limiteIzq, int limiteDer) // Método que realiza la búsqueda binaria, cada vez que el usuario le dice que el número ingresado por la pc es más < o mas > que el número elegido por ella.
        {//Elegí realizar búsqueda binaria por que es una de las eficientes.
            var lista = new Dictionary<string, int>();
            int numeroElegido = 0;

            if (tamanio == "grande")//Selecciona los límites del juego, a medida que este avanza los límites también cambian. Estos límites se guardan en variables de Sesión.
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