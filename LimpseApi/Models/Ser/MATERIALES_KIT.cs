using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class MATERIALES_KIT
    {
        [Key]
        public int IdMaterialKit { get; set; }
        public int IdKitServicio { get; set; }
        public int IdMaterial { get; set; }
        public int Cantidad { get; set; }
    }
}
