using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_Services
{
    public interface ILogin<T> where T : class 
    {
        Task<T?> Login(string Credential1, string Credential2);
    }
   
}
