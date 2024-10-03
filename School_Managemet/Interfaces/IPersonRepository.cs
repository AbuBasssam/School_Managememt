using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<bool> Update<Person>(Person person);
    }
}
