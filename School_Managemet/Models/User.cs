using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace School_Managemet_Repository.Models
{
    public class User
    {
        public int UserID {  get;   set; }
        public string UserName{ get; set; }
        public string Password{ get; set; }
        public int PersonID{ get;  set; }
        public bool IsActive {  get;  set; }

    }

    

}
