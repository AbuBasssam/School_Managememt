namespace School_Managemet_Repository.Models
{
    public class Student
    {
        public required int StudentID { get;  set; }
        public required DateTime EnrollmentDate { get; set; }
        public required byte GradeLevel { get; set; }
        public required int UserID { get; set; }
    }
}