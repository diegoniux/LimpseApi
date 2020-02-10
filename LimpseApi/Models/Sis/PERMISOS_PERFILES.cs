using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Sis
{
    public class PERMISOS_PERFILES
    {
        [Key]
        public int IdPermisoPerfil { get; set; }
        public int IdPerfil { get; set; }
        public int IdOpcion { get; set; }
    }
}
