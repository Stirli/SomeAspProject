using SomeAspProject.Services.Database.AdoDotNet;
using System.Collections.Generic;

namespace SomeAspProject.Services.Database
{
    public class SelectRequestResult : DatabaseRequestResult
    {
        public SelectRequestResult(ColumnDescription[] headers, List<object[]> rows)
        {
            Headers = headers;
            Rows = rows;
        }

        public ColumnDescription[] Headers { get; }
        public List<object[]> Rows { get; }
    }
}
