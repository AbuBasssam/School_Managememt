namespace School_Managemet_Repository.Models
{
    public class TeacherUser
    {
        public required Person Info { get; set; }
        public required User UserInfo { get; set; }
        public required Teacher TeacherInfo { get; set; }
    }


}
