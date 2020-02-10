using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Sis
{
    public class OPCIONES
    {
        [Key]
        public int IdOpcion { get; set; }
        public int IdMenu { get; set; }
        public string Opcion { get; set; }
        public string Ruta { get; set; }
        public string Imagen { get; set; }
    }
}
