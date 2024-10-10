namespace School_Managemet_Repository.Models
{
    public class TeacherView
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

        public string strGender { get; set; }
        public string NationalityName { get; set; }
        public string UserName { get; set; }
        public int TeacherID { get; set; }
        public string SubjectExpertise { get; set; }
        public string bio { get; set; }
        public int UserID { get; set; }

    }
}
