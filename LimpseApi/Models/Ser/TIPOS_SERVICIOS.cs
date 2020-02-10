using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class TIPOS_SERVICIOS
    {
        [Key]
        public int IdTipoServicio { get; set; }
        public string TipoServicio { get; set; }
    }
}
