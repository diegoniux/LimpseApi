using LimpseApi.Models;
using LimpseApi.Models.Ser;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LimpseApi.Data
{
    public class KitsRepository
    {
        private readonly string _connectionString;

        public KitsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        public async Task<List<KITS_SERVICIO>> GetAll()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarKitsServicio", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<KITS_SERVICIO>();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToValue(reader));
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

        private KITS_SERVICIO MapToValue(SqlDataReader reader)
        {
            return new KITS_SERVICIO()
            {
                IdKitServicio = (int)reader["IdKitServicio"],
                KitServicio = reader["KitServicio"].ToString(),
                Activo = (bool)reader["Activo"]
            };
        }

        public async Task<KITS_SERVICIO> GetById(int id)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarKitsServicio", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@p_IdKitServicio", id);
                        var response = new KITS_SERVICIO();
                        await sqlConn.OpenAsync();

                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response = MapToValue(reader);
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

        public async Task<ResultadoSP> Abc(int accion, string usuario, KITS_SERVICIO kit)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.Abc_KitsServicio", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_Accion", accion);
                        sqlCmd.Parameters.AddWithValue("@p_IdKitServicio", kit.IdKitServicio);
                        sqlCmd.Parameters.AddWithValue("@p_KitServicio", kit.KitServicio);
                        sqlCmd.Parameters.AddWithValue("@p_Activo", kit.Activo);
                        sqlCmd.Parameters.AddWithValue("@p_Usuario", usuario);

                        await sqlConn.OpenAsync();

                        var response = new ResultadoSP();
                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            await reader.ReadAsync();
                            response = new ResultadoSP();
                            response.Result = (int)reader["Result"];
                            //Si la ejecución es exitosa
                            if (response.Result == 1)
                            {
                                response.Id = (int)reader["Id"];
                            }
                            else 
                            {
                                response.ErrorMessage = reader["ErrorMessage"].ToString();
                                response.FriendlyMessage = reader["FriendlyMessage"].ToString();
                            }
                        }

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultadoSP()
                {
                    Result = 0,
                    ErrorMessage = ex.Message,
                    FriendlyMessage = "Ocurrió un error interno."
                };
            }
        }
    }
}
