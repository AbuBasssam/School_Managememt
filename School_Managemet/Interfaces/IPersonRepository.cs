using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Managemet_Repository.Models;

namespace School_Managemet_Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<bool> Update (PersonModel person);
    }
}
