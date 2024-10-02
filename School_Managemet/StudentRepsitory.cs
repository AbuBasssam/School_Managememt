using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using School_Managemet_Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository
{
    public class StudentRepsitory:IUserRepository
    {
        private readonly string _ConnectionString;
        public StudentRepsitory(string connectionString)
        {
            _ConnectionString = connectionString;   
        }

        public async Task<Student> GetByID(int StudentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_FindUserByUserNameAndPassword", connection))
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
                clsEventLog logger = new clsEventLog("StudentLogger");
                logger.LogEvent(ex.ToString(), LogLevel.Error);
            }

            return null;
        }
        
        private Student _MapReaderToStudent(IDataReader reader)
        {
            Student student = new Student();

            student.StudentID = reader.GetInt32(reader.GetOrdinal("StudentID"));
            student.StudentNumber = reader.GetString(reader.GetOrdinal("StudentNumber"));
            student.EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate"));
            student.GradeLevel = reader.GetByte(reader.GetOrdinal("GradeLevel"));
            student.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));

            return student;
                                
        }

    }
}
