using School_Managemet_Repository.Models;
using System.Data;
using System.Reflection;

namespace School_Managemet_Repository.Global
{
    public class DataMapper
    {

        public T MapReaderTo<T>(IDataReader reader) where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                {
                    var value = reader[property.Name];
                    property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
                }
            }

            return obj;
        }



        public T MapReaderToObjectWithCompstion<T>(IDataReader reader) where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // Check if the property is of a complex type
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    // Create an instance of the complex type
                    var nestedObject = Activator.CreateInstance(property.PropertyType);
                    var nestedProperties = property.PropertyType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                    // Map the nested properties
                    foreach (var nestedProperty in nestedProperties)
                    {
                        // Construct the expected column name
                        string columnName = $"{property.Name}.{nestedProperty.Name}";

                        // Check if the column exists in the reader
                        if (!reader.IsDBNull(reader.GetOrdinal(nestedProperty.Name)))
                        {
                            nestedProperty.SetValue(nestedObject, Convert.ChangeType(reader[nestedProperty.Name], nestedProperty.PropertyType));
                        }
                    }

                    property.SetValue(obj, nestedObject);
                }
                else
                {
                    // Handle simple properties
                    if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                    {
                        property.SetValue(obj, Convert.ChangeType(reader[property.Name], property.PropertyType));
                    }
                }
            }

            return obj;
        }
        //public StudentUserModel MapReaderToStudentUserModel(IDataReader reader)
        //{
        //    if (reader == null)
        //        throw new ArgumentNullException(nameof(reader));

        //    if (!reader.Read())
        //        return null; // No data to map

        //    var studentUser = new StudentUserModel();
        //    {
               
        //        {
        //            FirstName = reader["FirstName"] as string,
        //            LastName = reader["LastName"] as string
        //        },
        //        UserInfo = new UserModel
        //        {
        //            Username = reader["Username"] as string,
        //            Email = reader["Email"] as string
        //        },
        //        StudentInfo = new StudentModel
        //        {
        //            StudentId = reader["StudentId"] != DBNull.Value ? Convert.ToInt32(reader["StudentId"]) : 0,
        //            Grade = reader["Grade"] as string
        //        }
        //    };

        //    return studentUser;
        //}
    }


}
