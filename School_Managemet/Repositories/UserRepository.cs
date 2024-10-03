using School_Managemet_Repository.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Global;
using Microsoft.Extensions.Logging;



namespace School_Managemet_Repository.Repositories
{
    public class UserRepository: PersonRepository,IUserRepository
    {

        public UserRepository(string connectionString) : base(connectionString){}

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
                clsEventLog logger = new clsEventLog();
                logger.LogEvent(ex.ToString(), LogLevel.Error);
                return false;
            }



            return rowsAffected == 1;

        }
        
        /*public async Task<bool> DeactivateUser(string UserName)
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
        }*/

    }

}

