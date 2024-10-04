namespace School_Managemet_Repository.Models
{
    public class ParentUser
    {
        public required PersonModel Info { get; set; }
        public required User UserInfo { get; set; }
    }
}
