using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_Services
{
    public class Student : User,IStudent
    {
        private IStudentRepository _studentRepository;
        
        public StudentDTO DTO{ 
            get
            {
                PersonDTO PDTO = new PersonDTO(PersonID,NationalNo,FirstName,SecondName,ThirdName,LastName,
                                                Gender,NationalityID,DateOfBirth,
                                                Email,Phone,Address,ImagePath);
                
                UserDTO UDTO = new UserDTO(PDTO,UserID, UserName);
                
                return new StudentDTO(UDTO,StudentID,GradeLevel);
            } 
        }
        public int StudentID { get; private set; } 
        public DateTime EnrollmentDate { get; private set; } 
        public byte GradeLevel { get; set; }

        public Student(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository; 
        }
        
        private Student(IStudentRepository studentRepository,StudentUserDTO SUM) 
        {
            this._studentRepository = studentRepository;
            this.StudentID      = SUM.StudentInfo.StudentID;
            this.EnrollmentDate = SUM.StudentInfo.EnrollmentDate;
            this.GradeLevel     = SUM.StudentInfo.GradeLevel;
            
            this.UserID         = SUM.UserInfo.UserID;
            this.UserName       = SUM.UserInfo.UserName;
            this.Password       = SUM.UserInfo.Password;
            this.IsActive       = SUM.UserInfo.IsActive;
            
            this.PersonID       = SUM.Info.PersonID;
            this.NationalNo     = SUM.Info.NationalNO;
            this.FirstName      = SUM.Info.FirstName;
            this.SecondName     = SUM.Info.SecondName;
            this.ThirdName      = SUM.Info.ThirdName;
            this.LastName       = SUM.Info.LastName;
            this.DateOfBirth    = SUM.Info.DateOfBirth;
            this.Gender         = SUM.Info.Gender;
            this.NationalityID  = SUM.Info.Nationality;
            this.Email          = SUM.Info.Email;
            this.Phone          = SUM.Info.Phone;
            this.Address        = SUM.Info.Address;
            this.ImagePath      = SUM.Info.ImagePath;

            
        }
        
        public async Task<Student?> Login(string userName, string password)
        {
            var studentUser = await _studentRepository.Login(userName, password);
            return (studentUser != null) ? new Student(_studentRepository,studentUser): null;

        }


    }

   
    
}
