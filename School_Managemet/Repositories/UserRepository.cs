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
        
        

    }

}

