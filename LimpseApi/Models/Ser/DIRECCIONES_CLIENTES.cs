using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class DIRECCIONES_CLIENTES
    {
		[Key]
		public int IdDireccionCliente { get; set; }
		public int IdCliente { get; set; }
		public string Calle { get; set; }
		public string NoExt { get; set; }
		public string NoInt { get; set; }
		public string Colonia { get; set; }
		public string Ciudad { get; set; }
		public string CP { get; set; }
		public string Estado { get; set; }
	}
}
