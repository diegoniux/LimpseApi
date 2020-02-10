using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class ACCIONES_SISTEMA
    {
        [Key]
        public int IdAccionSistema { get; set; }
        public string AccionSistema { get; set; }
    }
}
