namespace School_Managemet_Repository.Models
{
    public class UserDTO
    {
        

        public string UserName{ get; set; }
        public string Password{ get; set; }
       

        public UserDTO(string userName, string password)
        {
            UserName = userName;
            Password = password;
           
        }
    }

    

}
