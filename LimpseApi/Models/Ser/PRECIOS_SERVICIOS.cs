using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class PRECIOS_SERVICIOS
    {
		[Key]
		public int IdPrecioServicio { get; set; }
		public int IdServicio { get; set; }
		public int IdUsuario { get; set; }
		public decimal Precio { get; set; }
		public DateTime FechaAlta { get; set; }
		public DateTime FechaAplicacion { get; set; }
	}
}
