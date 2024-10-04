using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_Services
{
    public class PersonDTO
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public int NationalityID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? ImagePath { get; set; }

        public PersonDTO(int personID, string nationalNo,
            string firstName, string secondName, string thirdName, string lastName,
            bool gender, int nationalityID, DateTime dateOfBirth,
            string email, string phone, string address, string? imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Gender = gender;
            NationalityID = nationalityID;
            DateOfBirth = dateOfBirth;
            Email = email;
            Phone = phone;
            Address = address;
            ImagePath = imagePath;
        }


    }
}
