using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class LOG_ORDENES_SERVICIO
    {
		[Key]
		public int IdLogOrdenServicio { get; set; }
		public int IdOrdenServicio { get; set; }
		public int IdEtapaOrdenServicio { get; set; }
		public int IdEstatusOrdenServicio { get; set; }
		public int IdUsuario { get; set; }
		public DateTime FechaCreacion { get; set; }
	}
}
