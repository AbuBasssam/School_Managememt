using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository.Models
{
   public class ChangePassword
    {
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
        public required string  UserName { get; set; }
    }
}
