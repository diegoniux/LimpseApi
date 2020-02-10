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
    public class MaterialesKitRepository
    {
        private readonly string _connectionString;

        public MaterialesKitRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        public async Task<List<MATERIALES_KIT>> GetAll()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarMaterialesKit", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<MATERIALES_KIT>();
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

        private MATERIALES_KIT MapToValue(SqlDataReader reader)
        {
            return new MATERIALES_KIT()
            {
                IdMaterialKit = (int)reader["IdMaterialKit"],
                IdKitServicio = (int)reader["IdKitServicio"],
                IdMaterial = (int)reader["IdMaterial"],
                Cantidad = (int)reader["Cantidad"]

            };
        }

        public async Task<List<MATERIALES_KIT>> GetByIdKit(int id)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarMaterialesKit", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@p_IdKitServicio", id);
                        var response = new List<MATERIALES_KIT>();
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

        public async Task<ResultadoSP> Abc(int accion, string usuario, MATERIALES_KIT materialKit)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.Abc_MaterialesKit", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_Accion", accion);
                        sqlCmd.Parameters.AddWithValue("@p_IdMaterialKit", materialKit.IdMaterialKit);
                        sqlCmd.Parameters.AddWithValue("@p_IdKitServicio", materialKit.IdKitServicio);
                        sqlCmd.Parameters.AddWithValue("@p_IdMaterial", materialKit.IdMaterial);
                        sqlCmd.Parameters.AddWithValue("@p_Cantidad", materialKit.Cantidad);
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
