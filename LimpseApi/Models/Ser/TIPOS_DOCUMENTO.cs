using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class TIPOS_DOCUMENTO
    {
        [Key]
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
    }
}
