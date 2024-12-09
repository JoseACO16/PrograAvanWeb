using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAvnzWeb.Models
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int TotalProducto { get; set; }
        public decimal Total { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string IdDistrito { get; set; }
        public DateTime FechaCompra { get; set; } = DateTime.Now;

        public ICollection<DetalleCompra> DetallesCompra { get; set; }
    }
}
