using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class PRECIOS_MATERIALES
    {
		[Key]
		public int IdPrecioMaterial { get; set; }
		public int IdMaterial { get; set; }
		public int IdUsuario { get; set; }
		public decimal Precio { get; set; }
		public DateTime FechaAlta { get; set; }
		public DateTime FechaAplicacion { get; set; }
	}
}
