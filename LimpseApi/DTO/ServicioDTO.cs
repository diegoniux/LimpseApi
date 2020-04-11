using LimpseApi.Models.Ser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.DTO
{
    public class ServicioDTO : SERVICIOS
    {
        public string TipoServicio { get; set; }
    }
}
