namespace School_Managemet_Repository.Models
{
    public class StudentUserDTO
    {
        

        public PersonDTO Info { get; set; }
        public UserDTO UserInfo { get; set; }
        public StudentDTO StudentInfo { get;set; }
        public StudentUserDTO(PersonDTO info, UserDTO userInfo, StudentDTO studentInfo)
        {
            Info = info;
            UserInfo = userInfo;
            StudentInfo = studentInfo;
        }
    }
}
