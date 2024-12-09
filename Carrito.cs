using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAvnzWeb.Models
{
    public class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
    }
}
