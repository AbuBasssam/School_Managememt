namespace School_Managemet_Repository.Models
{
    public class Teacher
    {
        public  int TeacherID { get; set; }
        public required string SubjectExpertise { get; set; }
        public required string bio { get; set; }
        public int UserID { get; set; }

    }




}
