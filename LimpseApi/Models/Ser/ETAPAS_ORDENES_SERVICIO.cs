using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class ETAPAS_ORDENES_SERVICIO
    {
        [Key]
        public int IdEtapaOrdenServicio { get; set; }
        public int IdEstatusOrdenServicio { get; set; }
        public string EtapaOrdenServicio { get; set; }
        public string Ruta { get; set; }
    }
}
