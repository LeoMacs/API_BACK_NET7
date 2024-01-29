using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndraApiBack.Models
{
    public class Empresa
    {
        [Key]
        public int idempresa { get; set; }
        public int nsucursal { get; set; }
        public string ruc { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }

    }
}
