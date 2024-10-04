namespace School_Managemet_Repository.Models
{
    public class StudentUserModel
    {
        public int PersonID { get; set; }
        public string NationalNO { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public byte Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? ImagePath { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int StudentID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public byte GradeLevel { get; set; }
    }
}
