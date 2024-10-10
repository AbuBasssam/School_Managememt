namespace School_Managemet_Repository.Models
{
    public class AddTeacher
    {
        public string NationalNO { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public byte Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? ImagePath { get; set; }
        public string Password { get; set; }
        public string SubjectExpertise { get; set; }
        public string bio { get; set; }

    }
}
