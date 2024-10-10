namespace School_Managemet_Repository.Models
{
    public class PersonDTO
    {
        public string NationalNO { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? ImagePath { get; set; }

        public PersonDTO(string nationalNO,string firstName, string secondName,
            string thirdName, string lastName,string gender, string nationality,
            DateTime dateOfBirth,string email, string phone, string address, string? imagePath)
        {
            NationalNO = nationalNO;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Gender = gender;
            Nationality = nationality;
            DateOfBirth = dateOfBirth;
            Email = email;
            Phone = phone;
            Address = address;
            ImagePath = imagePath;
        }


    }
}
