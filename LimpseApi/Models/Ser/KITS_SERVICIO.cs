using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class KITS_SERVICIO
    {
        [Key]
        public int IdKitServicio { get; set; }
        public string KitServicio { get; set; }
        public bool Activo { get; set; }
    }
}
