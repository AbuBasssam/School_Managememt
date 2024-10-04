using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using School_Managemet_Repository.Global;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Models;
using System.Data;

namespace School_Managemet_Repository.Repositories
{
    public class StudentRepsitory:UserRepository, IStudentRepository
    {
        public StudentRepsitory(string connectionString):base(connectionString){}

        public async Task<StudentUserModel?> Login(string UserName, string Password)
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
                                DataMapper mapper = new DataMapper();
                                return mapper.MapReaderTo<StudentUserModel>(reader);
                                //return _MapReaderToStudentUser(reader);

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

        /*        private Student _MapReaderToStudent(IDataReader reader)
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
*/

        /*private StudentUser _MapReaderToStudentUser(IDataReader reader)
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
*/

        /*        private StudentView _MapReaderToStudenView(IDataReader reader)
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
*/

    }
}
