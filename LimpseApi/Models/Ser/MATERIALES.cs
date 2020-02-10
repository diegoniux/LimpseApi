using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class MATERIALES
    {
        [Key]
        public int IdMaterial { get; set; }
        public int IdTipoMaterial { get; set; }
        public string Material { get; set; }
        public bool Activo { get; set; }
    }
}
