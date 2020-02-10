using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class CLIENTES
    {
		[Key]
		public int IdCliente { get; set; }
		public string RazonSocial { get; set; }
		public string Nombres { get; set; }
		public string ApellidoPaterno { get; set; }
		public string ApellidoMaterno { get; set; }
		public string RFC { get; set; }
		public string Email { get; set; }
		public bool Activo { get; set; }
	}
}
