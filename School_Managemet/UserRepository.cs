using School_Managemet_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace School_Managemet_Repository
{
    class UserRepository : IUserRepository
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
                var parameters = SqlParameterGenerater.CreateSqlParameters<Person>(person);
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
        public async Task<bool> ChangePassword(string OldPassword, string NewPassword)
        {

            int rowsAffected = 0;

            try
            {
               // var parameters = SqlParameterGenerater.CreateSqlParameters<Person>(person);
                using (var connection = new SqlConnection(_ConnectionString))
                {



                    using (var command = new SqlCommand("SP_Change_Password", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OldPassword",OldPassword);
                        command.Parameters.AddWithValue("@NewPassword", NewPassword);
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

    }
    
}

