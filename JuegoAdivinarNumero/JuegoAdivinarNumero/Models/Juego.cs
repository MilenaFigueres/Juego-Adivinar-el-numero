using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

//Clase del Juego
namespace JuegoAdivinarNumero.Models
{
    public class Juego : ValidationAttribute
    {
        [Range(1, 100, ErrorMessage = "El número debe estar entre 1 y 100")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor ingrese un número válido")]
        [Required(ErrorMessage = "Requerido")]
        public int numeroAleatorio { get; set; }
        [Range(1, 100, ErrorMessage = "El número debe estar entre 1 y 100")]
        public int numeroAdivinado { get; set; }
        public string respuesta { get; set; }
    }
}