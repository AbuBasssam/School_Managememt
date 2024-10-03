﻿using School_Managemet_Repository.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Global;

namespace School_Managemet_Repository.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly string _ConnectionString;

        public UserRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public async Task<bool> Update<Person>(Person person)
        {
            int rowsAffected = 0;

            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(person);
                using (var connection = new SqlConnection(_ConnectionString))
                {



                    using (var command = new SqlCommand("SP_Update_Person", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameters.ToArray());
                        connection.Open();
                        rowsAffected = await command.ExecuteNonQueryAsync();




                    }



                }
            }



            catch (Exception ex)
            {
                //clsEventLog.SetEventLog(ex.Message);
                return false;
            }



            return rowsAffected == 1;

        }

        //Tested
        public async Task<bool> ChangePassword(ChangePassword ChangePasswordModel)
        {

            int rowsAffected = 0;

            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(ChangePasswordModel);

                // var parameters = SqlParameterGenerater.CreateSqlParameters<Person>(person);
                using (var connection = new SqlConnection(_ConnectionString))
                {



                    using (var command = new SqlCommand("SP_Change_Password", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameters.ToArray());

                        connection.Open();
                        rowsAffected = await command.ExecuteNonQueryAsync();


                    }



                }
            }



            catch (Exception ex)
            {
                //clsEventLog.SetEventLog(ex.Message);
                return false;
            }



            return rowsAffected == 1;

        }
        public async Task<bool> DeactivateUser(string UserName)
        {
            int rowsAffected = 0;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Deactivate_User", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);


                        connection.Open();
                          await command.ExecuteNonQueryAsync();
                        rowsAffected=(int)returnParameter.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            return rowsAffected == 1;
        }







    }

}

