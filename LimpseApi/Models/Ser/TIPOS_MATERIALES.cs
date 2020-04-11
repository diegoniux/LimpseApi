using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class TIPOS_MATERIALES
    {
        [Key]
        public int IdTipoMaterial { get; set; }
        public string TipoMaterial { get; set; }
    }
}
