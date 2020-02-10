using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Sis
{
    public class MENUS
    {
        [Key]
        public int IdMenu { get; set; }
        public int IdModulo { get; set; }
        public string Menu { get; set; }
        public string Imagen { get; set; }
    }
}
