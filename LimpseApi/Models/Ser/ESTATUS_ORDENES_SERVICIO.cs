using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class ESTATUS_ORDENES_SERVICIO
    {
        [Key]
        public int IdEstatusOrdenServicio { get; set; }
        public string EstatusOrdenServicio { get; set; }
    }
}
