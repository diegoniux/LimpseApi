using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class PARAMETROS
    {
        [Key]
        public int IdParametro { get; set; }
        public string Clave { get; set; }
        public string Valor { get; set; }
    }
}
