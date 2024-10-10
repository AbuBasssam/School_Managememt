using School_Management_Domain;
using Microsoft.Data.SqlClient;
using School_Managemet_Repository.Global;
using School_Managemet_Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository.Repositories
{
    //Tested
    /// <summary>
    /// Repository for managing Person entities in the database.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        protected readonly string _ConnectionString;
        

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        public PersonRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        }


        /// <summary>
        /// Retrieves a Person by their ID.
        /// </summary>
        /// <param name="PersonID">The ID of the person.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the Person object if found, otherwise null.</returns>
        public async Task<Person?> GetByIDAsync(int PersonID)
        {
            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {

                    using (var command = new SqlCommand("SP_Get_Person_By_ID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        connection.Open();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return MapReaderToPerson(reader);

                            }



                        }

                    }

                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }


        /// <summary>
        /// Retrieves a Person by their National ID number.
        /// </summary>
        /// <param name="NationalNO">The National ID number of the person.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the Person object if found, otherwise null.</returns>
        public async Task<Person?> GetByNationalNOAsync(string NationalNO)
        {
            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {

                    using (var command = new SqlCommand("SP_Get_Person_By_NationalNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@NationalNO", NationalNO);
                        connection.Open();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return MapReaderToPerson(reader);

                            }



                        }

                    }

                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }


        /// <summary>
        /// Adds a new Person to the database.
        /// </summary>
        /// <param name="person">The Person object to add.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains the ID of the new Person if added successfully, otherwise null.</returns>
        public async Task<int?> AddAsync(Person person)
        {
            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(person);
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Add_New_Person", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter outputParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);
                        command.Parameters.AddRange(parameters.Skip(1).ToArray());

                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                        return (int)outputParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                //clsEventLog logger = new clsEventLog();
                //logger.LogEvent(ex.ToString(), LogLevel.Error);
            }
            return null;

        }


        /// <summary>
        /// Updates an existing Person in the database.
        /// </summary>
        /// <param name="person">The Person object with updated information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the update was successful.</returns>
        public async Task<bool> UpdateAsync(Person person)
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


                        var returnParameter = new SqlParameter("@rowsAffected", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(returnParameter);
                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                        rowsAffected = (int)returnParameter.Value;




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


        /// <summary>
        /// Deletes a Person by their ID.
        /// </summary>
        /// <param name="PersonID">The ID of the person to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
        public async Task <bool>DeleteAsync(int PersonID)
        {
            int rowsAffected = 0;

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {


                    using (var command = new SqlCommand("SP_Delete_Person_By_ID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        connection.Open();

                        rowsAffected = await command.ExecuteNonQueryAsync();

                    }



                }

            }
            catch (Exception ex)
            {
                //clsEventLog.SetEventLog(ex.Message, EventLogEntryType.Error);
            }

            return (rowsAffected == 1);

        }


        /// <summary>
        /// Retrieves a paginated list of PersonViews.
        /// </summary>
        /// <param name="PageNumber">The page number to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable list of PersonView objects.</returns>
        public async Task<IEnumerable<PersonView>> GetViewPageAsync(int PageNumber=1)
        {
            List<PersonView> PeopleList = new List<PersonView>();

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {


                    using (var command = new SqlCommand("SP_People_View_Page", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PageNumber", PageNumber);
                        connection.Open();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                PeopleList.Add(MapReaderToPersonView(reader));

                            }

                        }
                    }


                }



            }

            catch (Exception ex)
            {
               // clsEventLog.SetEventLog(ex.Message);
            }

            return PeopleList;
        }


        /// <summary>
        /// Retrieves a paginated list of Persons.
        /// </summary>
        /// <param name="PageNumber">The page number to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable list of Person objects.</returns>
        public async Task<IEnumerable<Person>> GetPageAsync(int PageNumber = 1)
        {
            List<Person> PeopleList = new List<Person>();

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {


                    using (var command = new SqlCommand("SP_People_Default_View_Page", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PageNumber", PageNumber);
                        connection.Open();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                PeopleList.Add(MapReaderToPerson(reader));

                            }

                        }
                    }


                }



            }

            catch (Exception ex)
            {
                // clsEventLog.SetEventLog(ex.Message);
            }

            return PeopleList;
        }


        /// <summary>
        /// Maps a data reader to a Person object.
        /// </summary>
        /// <param name="reader">The data reader containing Person data.</param>
        /// <returns>A Person object populated with data from the reader.</returns>
        private Person MapReaderToPerson(IDataReader reader)
        {
            /*DataMapper mapper = new DataMapper();
            return mapper.MapReaderTo<Person>(reader);*/

            return new Person
            {

                PersonID = reader.GetInt32(reader.GetOrdinal("PersonID")),
                NationalNO = reader.GetString(reader.GetOrdinal("NationalNO")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                SecondName = reader.GetString(reader.GetOrdinal("SecondName")),
                ThirdName = reader.GetString(reader.GetOrdinal("ThirdName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                Gender = Convert.ToByte(reader.GetBoolean(reader.GetOrdinal("Gender")) == true ? 1 : 0),
                Address = reader.GetString(reader.GetOrdinal("Address")),
                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Nationality = Convert.ToByte(reader.GetByte(reader.GetOrdinal("Nationality"))),
                ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? "" : reader.GetString(reader.GetOrdinal("ImagePath"))

            };
        }


        /// <summary>
        /// Maps a data reader to a PersonView object.
        /// </summary>
        /// <param name="reader">The data reader containing PersonView data.</param>
        /// <returns>A PersonView object populated with data from the reader.</returns>
        private PersonView MapReaderToPersonView(IDataReader reader)
        {
            DataMapper mapper = new DataMapper();
            return mapper.MapReaderTo<PersonView>(reader);

            /*return new PersonView
            {

                PersonID    = reader.GetInt32(reader.GetOrdinal("PersonID")),
                NationalNO  = reader.GetString(reader.GetOrdinal("NationalNO")),
                FirstName   = reader.GetString(reader.GetOrdinal("FirstName")),
                SecondName  = reader.GetString(reader.GetOrdinal("SecondName")),
                ThirdName   = reader.GetString(reader.GetOrdinal("ThirdName")),
                LastName    = reader.GetString(reader.GetOrdinal("LastName")),
                DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                Gender      = reader.GetString(reader.GetOrdinal("Gender")),
                Address     = reader.GetString(reader.GetOrdinal("Address")),
                Phone       = reader.GetString(reader.GetOrdinal("Phone")),
                Email       = reader.GetString(reader.GetOrdinal("Email")),
                Nationality = reader.GetString(reader.GetOrdinal("Nationality")),
                ImagePath   = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? "" : reader.GetString(reader.GetOrdinal("ImagePath"))

            };*/
        }

    }
}
