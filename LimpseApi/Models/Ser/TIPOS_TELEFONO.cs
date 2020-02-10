using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class TIPOS_TELEFONO
    {
        [Key]
        public int IdTipoTelefono { get; set; }
        public string TipoTelefono { get; set; }
    }
}
