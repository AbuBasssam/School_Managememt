using School_Managemet_Repository.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Global;
using Microsoft.Extensions.Logging;
using School_Management_Domain;

namespace School_Managemet_Repository.Repositories
{
    /// <summary>
    /// Repository for managing User entities in the database.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly string _ConnectionString;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        public UserRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        }


        /// <summary>
        /// Retrieves a User by their ID.
        /// </summary>
        /// <param name="UserID">The ID of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the User object if found, otherwise null.</returns>
        public async Task<User?> GetByIDAsync(int UserID)
        {
            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Get_User_By_ID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);
                        connection.Open();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return _MapReaderToUser(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log it, etc.)
            }
            return null;
        }


        /// <summary>
        /// Retrieves a User by their username.
        /// </summary>
        /// <param name="UserName">The username of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the User object if found, otherwise null.</returns>
        public async Task<User?> GetByUserNameAsync(string UserName)
        {
            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Get_User_By_UserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);
                        connection.Open();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return _MapReaderToUser(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log it, etc.)
            }
            return null;
        }


        /// <summary>
        /// Adds a new User to the database.
        /// </summary>
        /// <param name="User">The User object to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the new User if added successfully, otherwise null.</returns>
        public async Task<int?> AddAsync(User User)
        {
            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(User.AddUserParamerters);
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Add_New_User", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter outputParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);
                        command.Parameters.AddRange(parameters.ToArray()); // Send UserName and Password only

                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                        return (int)outputParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log it, etc.)
            }
            return null;
        }


        /// <summary>
        /// Updates an existing User in the database.
        /// </summary>
        /// <param name="User">The User object with updated information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the update was successful.</returns>
        public async Task<bool> UpdateAsync(User User)
        {
            int rowsAffected = 0;

            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(User);
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Update_User", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter returnParam = new SqlParameter("@rowsAffected", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParam);
                        command.Parameters.AddRange(parameters.GetRange(0, 3).ToArray());

                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                        rowsAffected = (int)returnParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log it, etc.)
                return false;
            }

            return rowsAffected == 1;
        }


        /// <summary>
        /// Deletes a User by their ID.
        /// </summary>
        /// <param name="UserID">The ID of the user to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
        public async Task<bool> DeleteAsync(int UserID)
        {
            int rowsAffected = 0;

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Delete_User_By_ID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter returnParam = new SqlParameter("@rowsAffected", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.Add(returnParam);

                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                        rowsAffected = (int)returnParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log it, etc.)
            }

            return (rowsAffected == 1);
        }


        /// <summary>
        /// Changes the password of a User.
        /// </summary>
        /// <param name="ChangePassword">The object containing change password details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the password change was successful.</returns>
        public async Task<bool> ChangePassword(ChangePassword ChangePassword)
        {
            int rowsAffected = 0;

            try
            {
                var parameters = SqlParameterGenerater.CreateSqlParameters(ChangePassword);
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_Change_Password", connection))
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
                // Log the error
                clsEventLog logger = new clsEventLog();
                logger.LogEvent(ex.ToString(), LogLevel.Error);
                return false;
            }

            return rowsAffected == 1;
        }


        /// <summary>
        /// Retrieves a paginated list of Users.
        /// </summary>
        /// <param name="PageNumber">The page number to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable list of User objects.</returns>
        public async Task<IEnumerable<User>> GetPageAsync(int PageNumber = 1)
        {
            List<User> UsersList = new List<User>();

            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    using (var command = new SqlCommand("SP_User_Page", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PageNumber", PageNumber);
                        connection.Open();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                UsersList.Add(_MapReaderToUser(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log it, etc.)
            }

            return UsersList;
        }


        /// <summary>
        /// Maps a data reader to a User object.
        /// </summary>
        /// <param name="reader">The data reader containing User data.</param>
        /// <returns>A User object populated with data from the reader.</returns>
        private User _MapReaderToUser(IDataReader reader)
        {
            return new User
            {
                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                Password = reader.GetString(reader.GetOrdinal("Password")),
                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                PersonID = reader.GetInt32(reader.GetOrdinal("PersonID"))
            };
        }


        /// <summary>
        /// Deactivates a User by their ID.
        /// </summary>
        /// <param name="UserID">The ID of the user to deactivate.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deactivation was successful.</returns>
        public async Task<bool> DeactivateAsync(int UserID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Deactivate_User", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        connection.Open();
                        await command.ExecuteNonQueryAsync();
                        rowsAffected = (int)returnParameter.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle exception (log it, etc.)
                return false;
            }

            return rowsAffected == 1;
        }
    }

}

