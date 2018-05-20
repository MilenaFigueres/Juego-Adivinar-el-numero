using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JuegoAdivinarNumero.Models
{
    public class Juego
    {
        [Range(1, 100, ErrorMessage = "El número debe estar entre 1 y 100")]
        public int numeroAleatorio { get; set; }
        public int numeroAdivinado { get; set; }
        public string respuesta { get; set; }
    }
}