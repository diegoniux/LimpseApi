using LimpseApi.Data;
using LimpseApi.Models;
using LimpseApi.Models.Ser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreciosServiciosController
    {
        private readonly PreciosServiciosRepository _repository;

        public PreciosServiciosController(PreciosServiciosRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<ResultadoSP> Post([FromBody] PRECIOS_SERVICIOS precioServicio)
        {
            try
            {
                return await _repository.RegistrarPrecioServicio("diegoniux", precioServicio);
            }
            catch (Exception ex)
            {
                return new ResultadoSP()
                {
                    Result = 0,
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Ups. Ocirrió un error interno."
                };
            }

        }

    }
}
