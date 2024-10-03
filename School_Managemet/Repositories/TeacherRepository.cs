using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using School_Managemet_Repository.Global;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Models;
using System.Data;

namespace School_Managemet_Repository.Repositories
{
    public class TeacherRepository:ITeacherRepository
    {
        private readonly string _ConnectionString;
        public TeacherRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public async Task<Teacher?> Get(int TeacherID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_Get_Teacher_By_ID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TeacherID", TeacherID);

                        connection.Open();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                DataMapper mapper = new DataMapper();
                                return mapper.MapReaderTo<Teacher>(reader);

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
        }

        public async Task<string?> Add(AddTeacher NewTeacherUser)
        {
            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(NewTeacherUser);
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Add_New_Teacher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.NVarChar)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);

                        command.Parameters.AddRange(parameters.ToArray());

                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                        return returnParameter.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //clsEventLog.SetEventLog(ex.Message);
            }
            return null;
        }

        public async Task<bool> Update<Person>(Person person)
        {
            UserRepository URepo = new UserRepository(_ConnectionString);
            return await URepo.Update(person);


        }

        public async Task<bool> ChangePassword(ChangePassword ChangePasswordModel)
        {
            UserRepository URepo = new UserRepository(_ConnectionString);
            return await URepo.ChangePassword(ChangePasswordModel);

        }

        public async Task<bool> Deactivate(string UserName)
        {
            UserRepository userRepository = new UserRepository(_ConnectionString);
            return await userRepository.DeactivateUser(UserName);
        }

        public async Task<TeacherUser?> Login(string UserName, string Password)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_Get_Teacher_User", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);


                        connection.Open();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                DataMapper mapper = new DataMapper();
                                return mapper.MapReaderTo<TeacherUser>(reader);

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
        }

        public async Task<bool> Delete(int TeacherID)
        {
            int rowsAffected = 0;

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {

                    using (var command = new SqlCommand("SP_Delete_Teacher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TeacherID", TeacherID);
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

                //clsEventLog.SetEventLog(ex.Message);
                return false;
            }

            return rowsAffected == 3;

        }

        public async Task<IEnumerable<TeacherView?>> GetTeachersPage(int Page = 1)
        {

            List<TeacherView> TeachersList = new List<TeacherView>();

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {


                    using (var command = new SqlCommand("SP_Teachers_List_With_Paging", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PageNumber", Page);
                        connection.Open();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            DataMapper mapper = new DataMapper();
                            while (await reader.ReadAsync())
                            {
                                TeachersList.Add(mapper.MapReaderTo<TeacherView>(reader));

                            }

                        }
                    }


                }



            }

            catch (Exception ex)
            {
                //clsEventLog.SetEventLog(ex.Message);
            }

            return TeachersList;
        }
        
        
        
        
        /*
        private Teacher _MapReaderToTeacher(IDataReader reader)
        {
            Teacher Teacher = new Teacher
            {

                TeacherID = reader.GetInt32(reader.GetOrdinal("TeacherID")),
                EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                GradeLevel = reader.GetByte(reader.GetOrdinal("GradeLevel")),
                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
            };
            return Teacher;

        }

        private TeacherUser _MapReaderToTeacherUser(IDataReader reader)
        {
            TeacherUser User = new TeacherUser
            {
                Info = new Person
                {
                    PersonID = reader.GetInt32(reader.GetOrdinal("PersonID")),
                    NationalNO = reader.GetString(reader.GetOrdinal("NationalNO")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    SecondName = reader.GetString(reader.GetOrdinal("SecondName")),
                    ThirdName = reader.GetString(reader.GetOrdinal("ThirdName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                    Gender = reader.GetBoolean(reader.GetOrdinal("Gender")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Nationality = reader.GetByte(reader.GetOrdinal("Nationality")),
                    ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath"))
                },

                UserInfo = new User
                {
                    // Initialize properties of User
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    PersonID = reader.GetInt32(reader.GetOrdinal("PersonID")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))

                },

                TeacherInfo = new Teacher
                {
                    // Initialize properties of Teacher
                    TeacherID = reader.GetInt32(reader.GetOrdinal("TeacherID")),
                    EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                    GradeLevel = reader.GetByte(reader.GetOrdinal("GradeLevel")),
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID"))

                }
            };

            return User;

        }

        private TeacherView _MapReaderToStudenView(IDataReader reader)
        {
            TeacherView Teacher = new TeacherView
            {

                PersonID = reader.GetInt32(reader.GetOrdinal("PersonID")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                SecondName = reader.GetString(reader.GetOrdinal("SecondName")),
                ThirdName = reader.GetString(reader.GetOrdinal("ThirdName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                Gender = reader.GetBoolean(reader.GetOrdinal("Gender")),
                strGender = reader.GetString(reader.GetOrdinal("strGender")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                Nationality = reader.GetByte(reader.GetOrdinal("Nationality")),
                NationalityName = reader.GetString(reader.GetOrdinal("NationalityName")),
                Address = reader.GetString(reader.GetOrdinal("Address")),
                ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                TeacherID = reader.GetInt32(reader.GetOrdinal("TeacherID")),
                TeacherNumber = reader.GetString(reader.GetOrdinal("TeacherNumber")),
                GradeLevel = reader.GetByte(reader.GetOrdinal("GradeLevel")),
                GradeLevelName = reader.GetString(reader.GetOrdinal("GradeLevelName"))


            };

            return Teacher;

        }*/
    }
}
