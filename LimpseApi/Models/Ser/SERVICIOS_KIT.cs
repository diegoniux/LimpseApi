using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class SERVICIOS_KIT
    {
        [Key]
        public int IdServicioKit { get; set; }
        public int IdKitServicio { get; set; }
        public int IdServicio { get; set; }
        public int Cantidad { get; set; }
    }
}
