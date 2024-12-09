using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAvnzWeb.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }
        public Marca Marca { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; } = 0;
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ICollection<Carrito> Carritos { get; set; }
        public ICollection<DetalleCompra> DetallesCompra { get; set; }
    }
}
