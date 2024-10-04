using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository.Repositories
{
    public class AdminRepository : UserRepository
    {
        public AdminRepository(string connectionString) : base(connectionString) { }

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

        /*public async Task<Student?> Get(int StudentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_Get_Student_By_ID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentID", StudentID);

                        connection.Open();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                DataMapper mapper = new DataMapper();
                                return mapper.MapReaderTo<Student>(reader);
                                 

                            }



                        }


                    }


                }

            }
            catch (Exception ex)
            {

                clsEventLog logger = new clsEventLog();
                logger.LogEvent(ex.ToString(), LogLevel.Error);
            }

            return null;
        }*/

        /*        public async Task<bool> UpgradeLevel(string UserName)
        {
            int rowsAffected = 0;
            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Upgrade_Student_Grade_Level", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);

                        connection.Open();
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog logger = new clsEventLog();
                logger.LogEvent(ex.ToString(), LogLevel.Error);
            }
            return rowsAffected == 1;
        }
*/

        /*        public async Task<string?> Add(AddStudent NewStudentUser)
        {
            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(NewStudentUser);
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Add_New_Student", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                         SqlParameter registerNumberParam = new SqlParameter("@RegisterNumber", SqlDbType.NVarChar, 10)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(registerNumberParam);
                        command.Parameters.AddRange(parameters.ToArray());

                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                        return registerNumberParam.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog logger = new clsEventLog();
                logger.LogEvent(ex.ToString(), LogLevel.Error);
            }
            return null;
        }
*/

        /*public async Task<bool> Delete(int StudentID)
        {
            int rowsAffected = 0;

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {

                    using (var command = new SqlCommand("SP_Delete_Student", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentID", StudentID);
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.NVarChar)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParameter);

                        connection.Open();

                        await command.ExecuteNonQueryAsync();
                        rowsAffected = (int)returnParameter.Value;

                    }


                }


            }
            catch (Exception ex)
            {

                clsEventLog logger = new clsEventLog();
                logger.LogEvent(ex.ToString(), LogLevel.Error);
                return false;
            }

            return rowsAffected == 3;

        }*/

        /* public async Task<IEnumerable<StudentView?>> GetStudentsPage(int Page = 1)
        {

            List<StudentView> StudentsList = new List<StudentView>();

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {


                    using (var command = new SqlCommand("SP_Students_List_With_Paging", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PageNumber", Page);
                        connection.Open();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataMapper mapper = new DataMapper();  
                            while (await reader.ReadAsync())
                            {
                                StudentsList.Add(mapper.MapReaderTo<StudentView>(reader));

                            }

                        }
                    }


                }



            }

            catch (Exception ex)
            {
                clsEventLog logger = new clsEventLog();
                logger.LogEvent(ex.ToString(), LogLevel.Error);
            }

            return StudentsList;
        }*/
    }
}
