using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_Services
{
    public interface ITeacher:ILogin<Teacher>,IPerson
    {
    }
}
