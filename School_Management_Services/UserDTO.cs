namespace School_Management_Services
{
    public class UserDTO
    {
        public PersonDTO Info { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        
        public UserDTO(int userID, string userName, PersonDTO info)
        {
            Info = info;
            UserID = userID;
            UserName = userName;
           
        }

    }
}
