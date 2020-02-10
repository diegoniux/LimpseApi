using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class EXPEDIENTE_ORDENES_SERVICIO
    {
        [Key]
        public int IdExpedienteOrdenServicio { get; set; }
        public int IdOrdenServicio { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Ruta { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
