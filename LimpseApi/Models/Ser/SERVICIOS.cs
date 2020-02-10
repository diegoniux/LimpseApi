using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class SERVICIOS
    {
        [Key]
        public int IdServicio { get; set; }
        public int IdTipoServicio { get; set; }
        public string Servicio { get; set; }
        public bool Activo { get; set; }
    }
}
