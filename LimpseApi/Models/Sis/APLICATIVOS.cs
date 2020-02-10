using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Sis
{
    public class APLICATIVOS
    {
        [Key]
        public int IdAplicativo { get; set; }
        public string Aplicativo { get; set; }
    }
}
