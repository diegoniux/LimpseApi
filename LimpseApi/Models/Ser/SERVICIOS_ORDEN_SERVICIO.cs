using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
	public class SERVICIOS_ORDEN_SERVICIO
	{
		[Key]
		public int IdServicioOrdenServicio { get; set; }
		public int IdOrdenServicio { get; set; }
		public int IdServicio { get; set; }
		public decimal Precio { get; set; }
		public int Cantidad { get; set; }
		public DateTime FechaCreacion { get; set; }
	}
}
