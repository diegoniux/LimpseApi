using LimpseApi.Data;
using LimpseApi.Models;
using LimpseApi.Models.Sis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController
    {
        private readonly LoginRepository _repository;

        public LoginController(LoginRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<LoginDTO> Post([FromBody] USUARIOS objUsuario)
        {
            try
            {
                return await _repository.LoginUser(objUsuario);
            }
            catch (Exception ex)
            {
                return new LoginDTO()
                {
                    ObjResultadoSP = new ResultadoSP()
                    {
                        Result = 0,
                        ErrorMessage = ex.Message,
                        FriendlyMessage = "Ups. Ocirrió un error interno."
                    }
                };
            }

        }

        [HttpGet("Modulos/{IdAplicativo}/{IdPerfil}")]
        public async Task<List<MODULOS>> GetModulos(int IdAplicativo, int IdPerfil)
        {
            try
            {
                return await _repository.ConsultarModulosAplicativoPerfil(IdAplicativo,IdPerfil);
            }
            catch (Exception)
            {
                return new List<MODULOS>();
            }

        }

        [HttpGet("Menus/{IdModulo}/{IdPerfil}")]
        public async Task<List<MENUS>> GetMenus(int IdModulo, int IdPerfil)
        {
            try
            {
                return await _repository.ConsultarMenusModuloPerfil(IdModulo, IdPerfil);
            }
            catch (Exception)
            {
                return new List<MENUS>();
            }

        }

        [HttpGet("Opciones/{IdMenu}/{IdPerfil}")]
        public async Task<List<OPCIONES>> GetOpciones(int IdMenu, int IdPerfil)
        {
            try
            {
                return await _repository.ConsultarOpcionesMenuPerfil(IdMenu, IdPerfil);
            }
            catch (Exception)
            {
                return new List<OPCIONES>();
            }

        }

    }
}
