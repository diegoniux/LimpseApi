using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Ser
{
    public class TECNICOS
    {
		[Key]
		public int IdTecnico { get; set; }
		public int IdUsuario { get; set; }
		public string Nombre { get; set; }
		public string ApellidoPaterno { get; set; }
		public string ApellidoMaterno { get; set; }
		public bool Activo { get; set; }
	}
}
