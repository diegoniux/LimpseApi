﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Models.Sis
{
    public class MODULOS
    {
        [Key]
        public int IdModulo { get; set; }
        public int IdAplicativo { get; set; }
        public string Modulo { get; set; }
        public string Ruta { get; set; }
        public bool Visible { get; set; }
    }
}
