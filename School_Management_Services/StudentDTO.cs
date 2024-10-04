namespace School_Management_Services
{
    public class StudentDTO
    {
        public UserDTO UserInfo { get; set; }
        public int StudentID { get; private set; }
        public byte GradeLevel { get; set; }

        public StudentDTO(int studentID, byte gradeLevel, UserDTO userInfo)
        {
            UserInfo = userInfo;
            StudentID = studentID;
            GradeLevel = gradeLevel;


        }

    }
    public class TeacherDTO
    {
        

        public UserDTO UserInfo { get; set; }
        public int TeacherID { get; set; }
        public string SubjectExpertise { get; set; }
        public string bio { get; set; }
        public TeacherDTO(UserDTO userInfo, int teacherID, string subjectExpertise, string bio)
        {
            UserInfo = userInfo;
            TeacherID = teacherID;
            SubjectExpertise = subjectExpertise;
            this.bio = bio;
        }


    }
}
