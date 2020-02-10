using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models
{
    public class ResultadoSP
    {
        public int Result { get; set; }
        public string ErrorMessage { get; set; }
        public string FriendlyMessage { get; set; }
        public int Id { get; set; }
    }
}
