namespace School_Management_Domain
{
    public class ChangePassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public int UserID { get; set; }
    }
}
