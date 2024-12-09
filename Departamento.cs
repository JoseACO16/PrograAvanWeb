using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAvnzWeb.Models
{
    public class Departamento
    {
        [Key]
        public string IdDepartamento { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Provincia> Provincias { get; set; }
    }
}
