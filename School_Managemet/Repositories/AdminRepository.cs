using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository.Repositories
{
    public class AdminRepository : UserRepository
    {
        public AdminRepository(string connectionString) : base(connectionString) { }

    }
}
