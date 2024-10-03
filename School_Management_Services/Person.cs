using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Managemet_Repository;
using School_Managemet_Repository.Interfaces;

namespace School_Management_Services
{
    public abstract class Person
    {
        private readonly IPersonRepository _personRepository;

        public int? PersonID { get; set; }
        public string NationalNo { get; set; } = string.Empty;     
        public string FirstName { get; set; } = string.Empty; 
        public string SecondName { get; set; } = string.Empty; 
        public string ThirdName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty; 
        public bool Gender { get; set; }             
        public int NationalityID { get; set; }       
        public DateTime DateOfBirth { get; set; }    
        public string Email { get; set; } = string.Empty; 
        public string Phone { get; set; } = string.Empty; 
        public string Address { get; set; } = string.Empty; 
        public string ImagePath { get; set; } = string.Empty;   


        /// <summary>
        /// method for update a user's Info.
        /// </summary>
        /// <param name="Info">The DTO containing User Info.</param>
        /// <returns>True if password change is successful, otherwise false.</returns>
        
        public async Task<bool> Update(IPersonRepository personRepository, Person Info)
        {
            return await _personRepository.Update(Info);

        }



    }
}

