using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAvnzWeb.Models
{
    public class DetalleCompra
    {
        [Key]
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public Compra Compra { get; set; }
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
