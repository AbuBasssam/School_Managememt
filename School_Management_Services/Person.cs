using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Managemet_Repository;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Models;
 

namespace School_Management_Services
{
    public abstract class Person
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; } 
        public string SecondName { get; set; }
        public string ThirdName { get; set; } 
        public string LastName { get; set; } 
        public bool Gender { get; set; }
        public byte NationalityID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? ImagePath { get; set; } 

        /// <summary>
        /// method for update a user's Info.
        /// </summary>
        /// <param name="Info">The DTO containing User Info.</param>
        /// <returns>True if password change is successful, otherwise false.</returns>

        public async Task<bool> Update(IPersonRepository personRepository, Person Info)
        {
            bool IsUpdated = await personRepository.Update(MapToModel(Info));

            return IsUpdated;

        }
        private  PersonModel MapToModel(Person Info)
        {
            PersonModel person=new PersonModel();
            person.PersonID = Info.PersonID;
            person.FirstName = Info.FirstName;
            person.SecondName = Info.SecondName;
            person.ThirdName = Info.ThirdName;
            person.LastName = Info.LastName;
            person.Gender = Info.Gender;
            person.Nationality = Info.NationalityID;
            person.DateOfBirth = Info.DateOfBirth;
            person.Email = Info.Email;
            person.Phone = Info.Phone;
            person.Address = Info.Address;
            person.ImagePath = Info.ImagePath;
            return person;


        }
    }
}

