using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SomeAspProject.Services.Database.AdoDotNet
{
    public class AdoDotNetDataService : IDatabaseService
    {
        private SqlConnection _sqlConnection;

        public AdoDotNetDataService(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            _sqlConnection.Dispose();
        }

        public async Task<DatabaseRequestResult> SendRequestAsync(string request)
        {
            DatabaseRequestResult result;
            try
            {
                SqlCommand sqlCommand = new SqlCommand(request, _sqlConnection);
                await _sqlConnection.OpenAsync();

                var reader = await sqlCommand.ExecuteReaderAsync();
                var headers = reader.GetColumnSchema().Select(c => new ColumnDescription { DataType = c.DataType, Name = c.ColumnName }).ToArray();
                var rows = new List<object[]>();
                while (await reader.ReadAsync())
                {
                    object[] buffer = new object[reader.FieldCount];
                    reader.GetValues(buffer);

                    rows.Add(buffer);
                }
                await _sqlConnection.CloseAsync();
                result = new DatabaseRequestResult()
                {
                    RecordsAffected = reader.RecordsAffected,
                    Headers = headers,
                    Rows = rows
                };
            }
            catch (Exception ex)
            {
                result = new DatabaseRequestResult(ex);
            }

            return result;
        }
    }
}
