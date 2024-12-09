using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAvnzWeb.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ICollection<Producto> Productos { get; set; }
    }
}
