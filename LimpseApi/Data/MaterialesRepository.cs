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
    public class MaterialesRepository
    {
        private readonly string _connectionString;

        public MaterialesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        public async Task<List<MATERIALES>> GetAll()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarMateriales", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<MATERIALES>();
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

        private MATERIALES MapToValue(SqlDataReader reader)
        {
            return new MATERIALES()
            {
                IdMaterial = (int)reader["IdMaterial"],
                IdTipoMaterial = (int)reader["IdTipoMaterial"],
                Material = reader["Material"].ToString(),
                Activo  = (bool)reader["Activo"]
            };
        }

        public async Task<MATERIALES> GetById(int id)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarMateriales", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@p_IdMaterial", id);
                        var response = new MATERIALES();
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

        public async Task<ResultadoSP> Abc(int accion, string usuario, MATERIALES material)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.Abc_Materiales", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@p_Accion", accion);
                        sqlCmd.Parameters.AddWithValue("@p_IdMaterial", material.IdMaterial);
                        sqlCmd.Parameters.AddWithValue("@p_IdTipoMaterial", material.IdTipoMaterial);
                        sqlCmd.Parameters.AddWithValue("@p_Material", material.Material);
                        sqlCmd.Parameters.AddWithValue("@p_Activo", material.Activo);
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
