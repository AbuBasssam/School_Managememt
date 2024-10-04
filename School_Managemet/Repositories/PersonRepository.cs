using Microsoft.Data.SqlClient;
using School_Managemet_Repository.Global;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository.Repositories
{
    public class PersonRepository:IPersonRepository
    {
        protected readonly string _ConnectionString;

        public PersonRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        public async Task<bool> Update(PersonModel person)
        {
            int rowsAffected = 0;

            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(person);
                using (var connection = new SqlConnection(_ConnectionString))
                {

                    using (var command = new SqlCommand("SP_Update_Person", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameters.ToArray());
                        connection.Open();
                        rowsAffected = await command.ExecuteNonQueryAsync();




                    }



                }
            }



            catch (Exception ex)
            {
                //clsEventLog.SetEventLog(ex.Message);
                return false;
            }



            return rowsAffected == 1;

        }

    }
}
