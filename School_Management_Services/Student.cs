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
        
        public StudentDTO DTO { 
            get
            {
                PersonDTO PDTO = new PersonDTO(PersonID,NationalNo,FirstName,SecondName,ThirdName,LastName,
                                                Gender,NationalityID,DateOfBirth,
                                                Email,Phone,Address,ImagePath);
                
                UserDTO UDTO = new UserDTO(UserID,UserName,PDTO);
                
                return new StudentDTO(StudentID,GradeLevel,UDTO);
            } 
        }
        public int StudentID { get; private set; } 
        public DateTime EnrollmentDate { get; private set; } 
        public byte GradeLevel { get; set; }

        public Student(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository; 
        }
        
        private Student(IStudentRepository studentRepository,StudentUserModel SUM) 
        {
            this._studentRepository = studentRepository;
            this.StudentID      = SUM.StudentID;
            this.EnrollmentDate = SUM.EnrollmentDate;
            this.GradeLevel     = SUM.GradeLevel;
            
            this.UserID         = SUM.UserID;
            this.UserName       = SUM.UserName;
            this.Password       = SUM.Password;
            this.IsActive       = SUM.IsActive;
            
            this.PersonID       = SUM.PersonID;
            this.NationalNo     = SUM.NationalNO;
            this.FirstName      = SUM.FirstName;
            this.SecondName     = SUM.SecondName;
            this.ThirdName      = SUM.ThirdName;
            this.LastName       = SUM.LastName;
            this.DateOfBirth    = SUM.DateOfBirth;
            this.Gender         = SUM.Gender;
            this.NationalityID  = SUM.Nationality;
            this.Email          = SUM.Email;
            this.Phone          = SUM.Phone;
            this.Address        = SUM.Address;
            this.ImagePath      = SUM.ImagePath;

            
        }
        
        public async Task<Student?> Login(string userName, string password)
        {
            var studentUser = await _studentRepository.Login(userName, password);
            return (studentUser != null) ? new Student(_studentRepository,studentUser): null;

        }


    }

   
    
}
