using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository
{
    public interface IGetData<T> where T : class
    {
        Task<T> GetByID(int ID);
    }
}
