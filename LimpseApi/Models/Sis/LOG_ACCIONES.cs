using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Sis
{
    public class LOG_ACCIONES
    {
        [Key]
        public int IdLogAccion { get; set; }
        public int IdUsuario { get; set; }
        public int IdAccion { get; set; }
        public int IdAplicativo { get; set; }
        public int IdOpcion { get; set; }
    }
}
