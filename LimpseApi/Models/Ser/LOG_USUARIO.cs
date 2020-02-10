using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class LOG_USUARIO
    {
        [Key]
        public int IdLogUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdAccionSistema { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Id { get; set; }
    }
}
