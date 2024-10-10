namespace School_Management_Domain
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int PersonID { get; set; }
        public AddUser AddUserParamerters
        {
            get
            {
                return new AddUser
                (
                    UserName = this.UserName,
                    Password = this.Password,
                    PersonID = this.PersonID
                );
            }
        }
    }

}
