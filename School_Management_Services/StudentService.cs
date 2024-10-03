using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_Services
{
    public class StudentService:User
    {
        public int? StudentID { get; private set; } = null;
        public DateTime EnrollmentDate { get; set; }= DateTime.Now;
        public byte GradeLevel { get; set; } = 0;

        public StudentService() { } 
        public StudentService(int? studentID,int? Userid,int personID,string username,string password,bool isActive, DateTime enrollmentDate, byte gradeLevel)
        {
            StudentID = studentID;
            UserID = Userid;
            PersonID = personID;
            UserName = username;
            Password = password;
            IsActive=isActive;
            EnrollmentDate = enrollmentDate;
            GradeLevel = gradeLevel;
        }

    }
}
