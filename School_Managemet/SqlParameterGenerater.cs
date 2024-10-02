using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace School_Managemet_Repository
{
    public static class SqlParameterGenerater
    {
        public static List<SqlParameter> CreateSqlParameters<T>(T entity)
        {
            var parameters = new List<SqlParameter>();

            // Get all public instance properties of the generic object, and skip the first property.
            foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = prop.GetValue(entity) ?? DBNull.Value; // Use DBNull for null values
                var parameterName = $"@{prop.Name}"; // Name the parameter based on the property name
                parameters.Add(new SqlParameter(parameterName, value));
            }

            return parameters;
        }



    }
}
