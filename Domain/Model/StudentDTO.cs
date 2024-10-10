namespace School_Managemet_Repository.Models
{
    public class StudentDTO
    {
        
        public  DateTime EnrollmentDate { get; set; }
        public byte GradeLevel { get; set; }

        public StudentDTO(DateTime enrollmentDate, byte gradeLevel)
        {
            EnrollmentDate = enrollmentDate;
            GradeLevel = gradeLevel;
        }
    }
}