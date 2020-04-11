using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Sis
{
    public class LoginDTO
    {
        public ResultadoSP ObjResultadoSP { get; set; }
        public USUARIOS ObjUsuario { get; set; }
        public PERFILES ObjPerfil { get; set; }
        public ESTATUS_USUARIO ObjEstatusUsuario { get; set; }

    }
}
