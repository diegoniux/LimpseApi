using LimpseApi.Models.Sis;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Data
{
    public class LoginRepository
    {

        private readonly string _connectionString; 
        public LoginRepository(IConfiguration configuration )
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        public async Task<LoginDTO> LoginUser(USUARIOS objUsuario) 
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Sis.prLoginUSer", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_Usuario", objUsuario.Usuario);
                        sqlCmd.Parameters.AddWithValue("@p_Password", objUsuario.Password);


                        await sqlConn.OpenAsync();

                        var response = new LoginDTO();
                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            await reader.ReadAsync();
                            response = new LoginDTO()
                            {
                                ObjResultadoSP = new Models.ResultadoSP(),
                                ObjEstatusUsuario = new ESTATUS_USUARIO(),
                                ObjPerfil = new PERFILES(),
                                ObjUsuario = new USUARIOS(),
                            };


                            response.ObjResultadoSP.Result = (int)reader["Result"];
                            //Si la ejecución es exitosa
                            if (response.ObjResultadoSP.Result == 1)
                            {
                                response.ObjResultadoSP.Id = (int)reader["IdUSuario"];

                                response.ObjUsuario = new USUARIOS()
                                {
                                    IdUsuario = (int)reader["IdUsuario"],
                                    IdPerfil = (int)reader["IdPerfil"],
                                    IdEstatusUsuario = (int)reader["IdEstatusUsuario"],
                                    Usuario = reader["Usuario"].ToString(),
                                    Email = reader["Email"].ToString()
                                };

                                response.ObjPerfil = new PERFILES()
                                {
                                    IdPerfil = (int)reader["IdPerfil"],
                                    Perfil = reader["Perfil"].ToString(),
                                    Activo = true
                                };

                                response.ObjEstatusUsuario = new ESTATUS_USUARIO()
                                {
                                    IdEstatusUsuario = (int)reader["IdEstatusUsuario"],
                                    EstatusUsuario = reader["EstatusUSuario"].ToString()
                                };

    }
                            else
                            {
                                response.ObjResultadoSP.ErrorMessage = reader["ErrorMessage"].ToString();
                                response.ObjResultadoSP.FriendlyMessage = reader["FriendlyMessage"].ToString();
                            }
                        }

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                return new LoginDTO ()
                {
                    ObjResultadoSP = new Models.ResultadoSP
                    {
                        Result = 0,
                        ErrorMessage = ex.Message,
                        FriendlyMessage = "Ocurrió un error interno."
                    }
                };
            }
        }

        public async Task<List<MODULOS>> ConsultarModulosAplicativoPerfil(int IdAplicativo, int IdPerfil)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Sis.prConsultarModulosAplicativoPerfil", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_IdAplicativo", IdAplicativo);
                        sqlCmd.Parameters.AddWithValue("@p_IdPerfil", IdPerfil);


                        await sqlConn.OpenAsync();

                        var response = new List<MODULOS>();
                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new MODULOS()
                                {
                                    IdModulo = (int)reader["IdModulo"],
                                    IdAplicativo = (int)reader["IdAplicativo"],
                                    Modulo = reader["Modulo"].ToString(),
                                    Ruta = reader["Ruta"].ToString()
                                });;
                            }

                        }

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MENUS>> ConsultarMenusModuloPerfil(int IdModulo, int IdPerfil)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Sis.prConsultarMenusModuloPerfil", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_IdModulo", IdModulo);
                        sqlCmd.Parameters.AddWithValue("@p_IdPerfil", IdPerfil);


                        await sqlConn.OpenAsync();

                        var response = new List<MENUS>();
                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new MENUS()
                                {
                                    IdMenu = (int)reader["IdMenu"],
                                    IdModulo = (int)reader["IdModulo"],
                                    Menu = reader["Menu"].ToString()
                                });
                            }

                        }

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OPCIONES>> ConsultarOpcionesMenuPerfil(int IdMenu, int IdPerfil)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Sis.prConsultarOpcionesMenuPerfil", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_IdMenu", IdMenu);
                        sqlCmd.Parameters.AddWithValue("@p_IdPerfil", IdPerfil);


                        await sqlConn.OpenAsync();

                        var response = new List<OPCIONES>();
                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new OPCIONES()
                                {
                                    IdOpcion = (int)reader["IdOpcion"],
                                    IdMenu = (int)reader["IdMenu"],
                                    Imagen = reader["Imagen"].ToString(),
                                    Opcion = reader["Opcion"].ToString(),
                                    Ruta = reader["Ruta"].ToString()
                                });
                            }

                        }

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
