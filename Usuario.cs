using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAvnzWeb.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get;set; }
        public string Correo { get; set;}
        public string Password { get; set; }
        public Boolean Administrador { get; set; } = true;
        public DateTime FechaRegistro { get; set; }= DateTime.Now;

        public ICollection<Carrito> Carritos { get; set; }
        public ICollection<Compra> Compras { get; set; }
    }
}
