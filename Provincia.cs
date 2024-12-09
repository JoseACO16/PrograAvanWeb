using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAvnzWeb.Models
{
    public class Provincia
    {
        [Key]
        public string IdProvincia { get; set; }
        public string Descripcion { get; set; }
        public string IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }

        public ICollection<Distrito> Distritos { get; set; }
    }
}
