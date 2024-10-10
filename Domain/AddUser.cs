namespace School_Management_Domain
{
    public class AddUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonID { get; set; }

        public AddUser(string userName, string password, int personID)
        {
            UserName = userName;
            Password = password;
            PersonID = personID;
        }
    }

}
