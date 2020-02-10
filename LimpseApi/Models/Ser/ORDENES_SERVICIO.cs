using Microsoft.SqlServer.Types;
using System;
using System.ComponentModel.DataAnnotations;

namespace LimpseApi.Models.Ser
{
    public class ORDENES_SERVICIO
    {
		[Key]
		public int IdOrdenServicio { get; set; }
		public int IdCliente { get; set; }
		public int IdTecnico { get; set; }
		public int IdEstatusOrdenServicio { get; set; }
		public SqlGeography Ubicacion { get; set; }
		public DateTime FechaAlta { get; set; }
	}
}
