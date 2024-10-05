using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Models;
using School_Managemet_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_Services
{
    public class Teacher: User,ITeacher
    {
        private ITeacherRepository _teacherRepository;

        public TeacherDTO DTO
        {
            get
            {
                PersonDTO PDTO = new PersonDTO(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                                Gender, NationalityID, DateOfBirth,
                                                Email, Phone, Address, ImagePath);

                UserDTO UDTO = new UserDTO(UserID, UserName, PDTO);
                return new TeacherDTO(UDTO, TeacherID, SubjectExpertise, bio);
            }
        }
        public int TeacherID { get;private set; }
        public string SubjectExpertise { get; set; }
        public string bio { get; set; }
        public Teacher(ITeacherRepository teacherRepository)
        {
          this._teacherRepository = teacherRepository;
          
          this.TeacherID = -1;
          this.SubjectExpertise = "";
          this.bio ="";
        }
        private Teacher(ITeacherRepository teacherRepository,TeacherUserModel TUM)
        {
            this._teacherRepository = teacherRepository;

            this.TeacherID = TUM.TeacherID;
            this.SubjectExpertise = TUM.SubjectExpertise;
            this.bio = TUM.bio;

            this.UserID = TUM.UserID;
            this.UserName = TUM.UserName;
            this.Password = TUM.Password;
            this.IsActive = TUM.IsActive;

            this.PersonID = TUM.PersonID;
            this.NationalNo = TUM.NationalNO;
            this.FirstName = TUM.FirstName;
            this.SecondName = TUM.SecondName;
            this.ThirdName = TUM.ThirdName;
            this.LastName = TUM.LastName;
            this.DateOfBirth = TUM.DateOfBirth;
            this.Gender = TUM.Gender;
            this.NationalityID = TUM.Nationality;
            this.Email = TUM.Email;
            this.Phone = TUM.Phone;
            this.Address = TUM.Address;
            this.ImagePath = TUM.ImagePath;

        }

        public async Task<Teacher?> Login(string userName, string password)
        {
            var teacherUser = await _teacherRepository.Login(userName, password);
            return (teacherUser != null) ? new Teacher(_teacherRepository, teacherUser) : null;

        }
       
    }
}
