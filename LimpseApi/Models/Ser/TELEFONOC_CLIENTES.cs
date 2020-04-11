using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
	public class TELEFONOS_CLIENTES
	{
		[Key]
		public int IdTelefonoCliente { get; set; }
		public int IdCliente { get; set; }
		public int IdTipoTelefono { get; set; }
		public string Telefono { get; set; }
	}
}
