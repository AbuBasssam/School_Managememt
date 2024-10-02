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
        public required int UserID {  get;   set; }
        public required string UserName{ get; set; }
        public required string Password{ get; set; }
        public required int PersonID{ get;  set; }
        public required bool IsActive {  get;  set; }

    }

    

}
