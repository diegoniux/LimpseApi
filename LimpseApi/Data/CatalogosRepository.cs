using LimpseApi.Models.Ser;
using LimpseApi.Models.Sis;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Data
{
    public class CatalogosRepository
    {
        private readonly string _connectionString;
        public CatalogosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        public async Task<List<ESTATUS_ORDENES_SERVICIO>> GetEstatusOrdenesServicio()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarEstatusOrdenesServicio", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<ESTATUS_ORDENES_SERVICIO>();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new ESTATUS_ORDENES_SERVICIO()
                                {
                                    IdEstatusOrdenServicio = (int)reader["IdEstatusOrdenServicio"],
                                    EstatusOrdenServicio = reader["EstatusOrdenServicio"].ToString()
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

        public async Task<List<ETAPAS_ORDENES_SERVICIO>> GetEtapasOrdenesServicio()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarEtapasOrdenesServicio", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<ETAPAS_ORDENES_SERVICIO>();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new ETAPAS_ORDENES_SERVICIO()
                                {
                                    IdEtapaOrdenServicio = (int)reader["IdEtapaOrdenServicio"],
                                    EtapaOrdenServicio = reader["EtapaOrdenServicio"].ToString(),
                                    IdEstatusOrdenServicio =  (int)reader["IdEstatusOrdenServicio"],
                                    Ruta = reader["Ruta"].ToString(),

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

        public async Task<List<TIPOS_DOCUMENTO>> GetTiposDocumento()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarTiposDocumento", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<TIPOS_DOCUMENTO>();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new TIPOS_DOCUMENTO()
                                {
                                    IdTipoDocumento = (int)reader["IdTipoDocumento"],
                                    TipoDocumento = reader["TipoDocumento"].ToString(),

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

        public async Task<List<TIPOS_MATERIALES>> GetTiposMaterial()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarTiposMaterial", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<TIPOS_MATERIALES>();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new TIPOS_MATERIALES()
                                {
                                    IdTipoMaterial = (int)reader["IdTipoMaterial"],
                                    TipoMaterial = reader["TipoMaterial"].ToString(),
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

        public async Task<List<TIPOS_SERVICIOS>> GetTiposServicio()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarTiposServicio", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<TIPOS_SERVICIOS>();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new TIPOS_SERVICIOS()
                                {
                                    IdTipoServicio = (int)reader["IdTipoServicio"],
                                    TipoServicio = reader["TipoServicio"].ToString(),
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

        public async Task<List<TIPOS_TELEFONO>> GetTiposTelefono()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarTiposTelefono", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<TIPOS_TELEFONO>();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new TIPOS_TELEFONO()
                                {
                                    IdTipoTelefono = (int)reader["IdTipoTelefono"],
                                    TipoTelefono = reader["TipoTelefono"].ToString(),
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

        public async Task<List<PERFILES>> GetPerfiles()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Sis.prConsultarPerfiles", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<PERFILES>();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new PERFILES()
                                {
                                    IdPerfil = (int)reader["IdPerfil"],
                                    Perfil = reader["Perfil"].ToString(),
                                    Activo = (bool)reader["Activo"]
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

        public async Task<List<ESTATUS_USUARIO>> GetEstatusUsuario()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Sis.prConsultarEstatusUsuario", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<ESTATUS_USUARIO>();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(new ESTATUS_USUARIO()
                                {
                                    IdEstatusUsuario = (int)reader["IdEstatusUsuario"],
                                    EstatusUsuario = reader["EstatusUsuario"].ToString()
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
