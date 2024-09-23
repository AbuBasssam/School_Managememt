using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository
{
    public interface IDeleteData
    {
        Task<int?> Delete(int ID);
    }
}
