using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Sis
{
    public class ESTATUS_USUARIO
    {
        [Key]
        public int IdEstatusUsuario { get; set; }
        public string EstatusUsuario { get; set; }
    }
}
