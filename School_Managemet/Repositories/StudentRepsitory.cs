using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Models;
using System.Data;

namespace School_Managemet_Repository.Repositories
{
    public class StudentRepsitory:IStudentRepository
    {
        private readonly string _ConnectionString;
        public StudentRepsitory(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public async Task<Student> Get(int StudentID)
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

                                return _MapReaderToStudent(reader);

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

        public async Task<string?> Add(AddStudent NewStudentUser)
        {
            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(NewStudentUser);
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Add_New_Student", connection))
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

        public async Task<bool> UpgradeLevel(string UserName)
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
                //clsEventLog.SetEventLog(ex.Message);
            }
            return rowsAffected == 1;
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

        public async Task<StudentUser?> Login(string UserName, string Password)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_Get_Student_User", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);


                        connection.Open();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {

                                return _MapReaderToStudentUser(reader);

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

        public async Task<bool> Delete(int StudentID)
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

                //clsEventLog.SetEventLog(ex.Message);
                return false;
            }

            return rowsAffected == 3;

        }

        public async Task<IEnumerable<StudentView?>> GetStudentsPage(int Page = 1)
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
                            while (await reader.ReadAsync())
                            {
                                StudentsList.Add(_MapReaderToStudenView(reader));

                            }

                        }
                    }


                }



            }

            catch (Exception ex)
            {
                //clsEventLog.SetEventLog(ex.Message);
            }

            return StudentsList;
        }

        private Student _MapReaderToStudent(IDataReader reader)
        {
            Student student = new Student
            {

                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                GradeLevel = reader.GetByte(reader.GetOrdinal("GradeLevel")),
                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
            };
            return student;

        }

        private StudentUser _MapReaderToStudentUser(IDataReader reader)
        {
            StudentUser User = new StudentUser
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

                StudentInfo = new Student
                {
                    // Initialize properties of Student
                    StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                    EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                    GradeLevel = reader.GetByte(reader.GetOrdinal("GradeLevel")),
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID"))

                }
            };

            return User;

        }

        private StudentView _MapReaderToStudenView(IDataReader reader)
        {
            StudentView Student = new StudentView
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
                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                StudentNumber = reader.GetString(reader.GetOrdinal("StudentNumber")),
                GradeLevel = reader.GetByte(reader.GetOrdinal("GradeLevel")),
                GradeLevelName = reader.GetString(reader.GetOrdinal("GradeLevelName"))


            };

            return Student;

        }


    }
}
