namespace School_Management_Services
{
    public class UserDTO
    {
        public PersonDTO Info { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        
        public UserDTO(PersonDTO info,int userID, string userName )
        {
            Info = info;
            UserID = userID;
            UserName = userName;
           
        }

    }
}
