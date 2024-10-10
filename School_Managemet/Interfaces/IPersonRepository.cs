using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Management_Domain;

namespace School_Managemet_Repository.Interfaces
{
    public interface IPersonRepository:IGenericRepository<Person>
    {
        Task<Person?> GetByNationalNOAsync(string NationalNO);
        Task<IEnumerable<PersonView>> GetViewPageAsync(int PageNumber = 1);
    }
}
