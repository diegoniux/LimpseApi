using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Sis
{
    public class PERFILES
    {
        [Key]
        public int IdPerfil { get; set; }
        public string Perfil { get; set; }
        public bool Activo { get; set; }
    }
}
