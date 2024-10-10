namespace School_Managemet_Repository.Models
{
    public class AddStudent
    {
        public required string NationalNO { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string ThirdName { get; set; }
        public required string LastName { get; set; }
        public byte Gender { get; set; }
        public byte Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public string? ImagePath { get; set; }
        public required string Password { get; set; }
        public byte GradeLevel {  get; set; }


    }
}
