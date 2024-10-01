using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository.Models
{
    public class StudentUser
    {
        public required Person Info { get; set; }
        public required User UserInfo { get; set; }
        public required Student StudentInfo { get; set; }
    }
}
