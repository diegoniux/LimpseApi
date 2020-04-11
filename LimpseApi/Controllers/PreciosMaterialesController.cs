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
    public class PreciosMaterialesController
    {
        private readonly PreciosMaterialesRepository _repository;

        public PreciosMaterialesController(PreciosMaterialesRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<ResultadoSP> Post([FromBody] PRECIOS_MATERIALES precioMaterial)
        {
            try
            {
                return await _repository.RegistrarPrecioMaterial("diegoniux", precioMaterial);
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
