using School_Management_Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using School_Managemet_Repository.Global;
using School_Managemet_Repository.Interfaces;
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

                               return _MapReaderToStudentUser(reader);

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

        public async Task<Student?> GetByIDAsync(int StudentID)
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
                                return _AutoMapReaderToStudent(reader);

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

        public async Task<StudentUser?> GetByUsernameAsync(string UserName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_Get_Student_By_UserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);

                        connection.Open();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                                return _MapReaderToStudentUser(reader);

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

        public async Task<string?> AddAsync(StudentUser NewStudentUser)
        {
            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(NewStudentUser.Info);
               // parameters.AddRange(SqlParameterGenerater.CreateSqlParameters(NewStudentUser.UserInfo));
                parameters.AddRange(SqlParameterGenerater.CreateSqlParameters(NewStudentUser.StudentInfo));

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
                //clsEventLog logger = new clsEventLog();
                //logger.LogEvent(ex.ToString(), LogLevel.Error);
            }
            return null;
        }

        public async Task<int?> AddAsync(Student student)
        {
            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(student);
               


                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Add_New_Student_By_Exists_User", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter registerNumberParam = new SqlParameter("@NewStudentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(registerNumberParam);
                        command.Parameters.AddRange(parameters.GetRange(2, 2).ToArray());

                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                        return (int?)registerNumberParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                //clsEventLog logger = new clsEventLog();
                //logger.LogEvent(ex.ToString(), LogLevel.Error);
            }
            return null;
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
                clsEventLog logger = new clsEventLog();
                logger.LogEvent(ex.ToString(), LogLevel.Error);
            }
            return rowsAffected == 1;
        }

        public async Task<bool> DeleteAsync(string UserName)
        {
            int rowsAffected = 0;

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {

                    using (var command = new SqlCommand("SP_Delete_Student_By_UserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);
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

        }

        public async Task<bool> DeleteAsync(int StudentID)
        {
            int rowsAffected = 0;

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {

                    using (var command = new SqlCommand("SP_Delete_Student_By_ID", connection))
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
        }
        
        public async Task<bool>ChangePassword(ChangePassword changePassword)
        {
            UserRepository userRepo= new UserRepository(_ConnectionString);
           return  await userRepo.ChangePassword(changePassword); 
        }

        public async Task<IEnumerable<Student>> GetPageAsync(int PageNumber=1)
        {
            List<Student> StudentsList = new List<Student>();

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {


                    using (var command = new SqlCommand("SP_Student_Page", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PageNumber", PageNumber);
                        connection.Open();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                StudentsList.Add(_AutoMapReaderToStudent(reader));

                            }

                        }
                    }


                }



            }

            catch (Exception ex)
            {
                // clsEventLog.SetEventLog(ex.Message);
            }

            return StudentsList;
        }

        private StudentUser _MapReaderToStudentUser(IDataReader reader)
        {
           StudentUser StudentUser = new StudentUser();

            // Initialize properties of Person
                StudentUser.Info = new Person();
                StudentUser.Info.PersonID = reader.GetInt32(reader.GetOrdinal("PersonID"));
                StudentUser.Info.NationalNO = reader.GetString(reader.GetOrdinal("NationalNO"));
                StudentUser.Info.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                StudentUser.Info.SecondName = reader.GetString(reader.GetOrdinal("SecondName"));
                StudentUser.Info.ThirdName = reader.GetString(reader.GetOrdinal("ThirdName"));
                StudentUser.Info.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                StudentUser.Info.DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));
                StudentUser.Info.Gender = Convert.ToByte(reader.GetBoolean(reader.GetOrdinal("Gender")) == true ? 1 : 0);
                StudentUser.Info.Address = reader.GetString(reader.GetOrdinal("Address"));
                StudentUser.Info.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                StudentUser.Info.Email = reader.GetString(reader.GetOrdinal("Email"));
                StudentUser.Info.Nationality = Convert.ToByte(reader.GetByte(reader.GetOrdinal("Nationality")));
                StudentUser.Info.ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? "" : reader.GetString(reader.GetOrdinal("ImagePath"));

            // Initialize properties of User
                StudentUser.UserInfo = new User();
                StudentUser.UserInfo.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                StudentUser.UserInfo.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                StudentUser.UserInfo.Password = reader.GetString(reader.GetOrdinal("Password"));
                StudentUser.UserInfo.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                StudentUser.UserInfo.PersonID = reader.GetInt32(reader.GetOrdinal("PersonID"));

            // Initialize properties of student
                StudentUser.StudentInfo = new Student();
                StudentUser.StudentInfo.StudentID = reader.GetInt32(reader.GetOrdinal("StudentID"));
                StudentUser.StudentInfo.EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate"));
                StudentUser.StudentInfo.GradeLevel = Convert.ToByte(reader.GetByte(reader.GetOrdinal("GradeLevel")));
                StudentUser.StudentInfo.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));

            return StudentUser;

        }
        
        private Student _AutoMapReaderToStudent(IDataReader reader)
        {
            Student Student = new Student();
            DataMapper mapper = new DataMapper();

            // Initialize properties of student
            Student = mapper.MapReaderTo<Student>(reader);

            return Student;




        }

        public async Task<bool>UpdateAsync(Student student)
        {
            int rowsAffected = 0;

            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(student);
                using (var connection = new SqlConnection(_ConnectionString))
                {

                    using (var command = new SqlCommand("SP_Update_Student", connection))
                    {
                        SqlParameter returnParam = new SqlParameter("@rowsAffected", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParam);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameters.ToArray());

                        connection.Open();
                         await command.ExecuteNonQueryAsync();
                        rowsAffected = (int)returnParam.Value;


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

        public async Task<bool>UpdateAsync(Person person)
       {
            PersonRepository personRepo= new PersonRepository(_ConnectionString);
           return await personRepo.UpdateAsync(person);
       }

        public async Task<IEnumerable<StudentView>> GetStudentsViewPageAsync(int Page = 1)
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
                            //DataMapper mapper = new DataMapper();
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
                clsEventLog logger = new clsEventLog();
                logger.LogEvent(ex.ToString(), LogLevel.Error);
            }

            return StudentsList;
        }

        private StudentView _MapReaderToStudenView(IDataReader reader)
        {
            StudentView Student = new StudentView();
            {

                Student.info.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                Student.info.SecondName = reader.GetString(reader.GetOrdinal("SecondName"));
                Student.info.ThirdName = reader.GetString(reader.GetOrdinal("ThirdName"));
                Student.info.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                Student.info.DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));
                Student.info.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                Student.info.Email = reader.GetString(reader.GetOrdinal("Email"));
                Student.info.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                Student.info.Nationality = reader.GetString(reader.GetOrdinal("Nationality"));
                Student.info.Address = reader.GetString(reader.GetOrdinal("Address"));
                Student.StudentNumber = reader.GetString(reader.GetOrdinal("StudentNumber"));
                Student.GradeLevel = reader.GetString(reader.GetOrdinal("GradeLevel"));


            };

            return Student;

        }

        /*private Student _MapReaderToStudent(IDataReader reader)
        {
            Student student = new Student
            {

                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                GradeLevel = reader.GetByte(reader.GetOrdinal("GradeLevel")),
                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
            };
            return student;

        }*/

    }
}
