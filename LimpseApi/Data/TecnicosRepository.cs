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
    public class TecnicosRepository
    {
        private readonly string _connectionString;

        public TecnicosRepository(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("LimpseDataBase");
        }

        public async Task<List<TECNICOS>> GetAll()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarTecnicos", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<TECNICOS>();
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

        private TECNICOS MapToValue(SqlDataReader reader)
        {
            return new TECNICOS()
            {
                IdTecnico = (int)reader["IdTecnico"],
                IdUsuario = (int)reader["IdUsuario"],
                Nombre = reader["Nombre"].ToString(),
                ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                Activo = (bool)reader["Activo"]
            };
        }

        public async Task<TECNICOS> GetById(int id)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.prConsultarTecnicos", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@p_IdTecnico", id);
                        var response = new TECNICOS();
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

        public async Task<ResultadoSP> Abc(int accion, string usuario, TECNICOS tecnico)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("Ser.Abc_Tecnicos", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        sqlCmd.Parameters.AddWithValue("@p_Accion", accion);
                        sqlCmd.Parameters.AddWithValue("@p_IdTecnico",tecnico.IdTecnico);
                        sqlCmd.Parameters.AddWithValue("@p_IdUsuarioTecnico", tecnico.IdUsuario);
                        sqlCmd.Parameters.AddWithValue("@p_Nombre", tecnico.Nombre);
                        sqlCmd.Parameters.AddWithValue("@p_ApellidoPaterno", tecnico.ApellidoPaterno);
                        sqlCmd.Parameters.AddWithValue("@p_ApellidoMaterno", tecnico.ApellidoMaterno);
                        sqlCmd.Parameters.AddWithValue("@p_Activo", tecnico.Activo);
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
