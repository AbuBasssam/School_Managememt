using School_Managemet_Repository.Models;
using School_Managemet_Repository.Repositories;


namespace School_Management_Services
{
    public abstract class Person:IPerson
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

        public async Task<bool> Update(UpdatePersonDTO Info)
        {
            string ConnectionString = "Server=.;Database=SchoolDB;User Id=sa;Password=sa123456;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";
            PersonRepository personRepository = new PersonRepository(ConnectionString);
            bool IsUpdated = await personRepository.Update(MapToModel(Info));

            return IsUpdated;

        }
        
        private  PersonModel MapToModel(UpdatePersonDTO Info)
        {
            PersonModel person=new PersonModel();
            person.PersonID = Info.PersonID;
            person.NationalNO = Info.NationalNo;
            person.FirstName = Info.FirstName;
            person.SecondName = Info.SecondName;
            person.ThirdName = Info.ThirdName;
            person.LastName = Info.LastName;
            person.Gender = Info.Gender;
            person.Nationality = Info.Nationality;
            person.DateOfBirth = Info.DateOfBirth;
            person.Email = Info.Email;
            person.Phone = Info.Phone;
            person.Address = Info.Address;
            person.ImagePath = this.ImagePath;
            return person;


        }
    }
}

