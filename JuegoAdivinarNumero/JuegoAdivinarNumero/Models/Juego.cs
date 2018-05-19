using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JuegoAdivinarNumero.Models
{
    public class Juego
    {
        public int numeroAleatorio { get; set; }
        public int numeroAdivinado { get; set; }
        public string respuesta { get; set; }
    }
}