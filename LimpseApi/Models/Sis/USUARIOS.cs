using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Sis
{
    public class USUARIOS
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public int IdPerfil { get; set; }
        public int IdEstatusUsuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
