using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAvnzWeb.Models
{
    public class Distrito
    {
        [Key]
        public string IdDistrito { get; set; }
        public string Descripcion { get; set; }
        public string IdProvincia { get; set; }
        public Provincia Provincia { get; set; }
        public string IdDepartamento { get; set; }
    }
}
