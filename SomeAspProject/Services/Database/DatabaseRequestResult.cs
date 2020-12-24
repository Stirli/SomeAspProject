using SomeAspProject.Services.Database.AdoDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SomeAspProject.Services.Database
{
    public class DatabaseRequestResult
    {
        public DatabaseRequestResult()
        {
            IsSuccess = true;
        }
        public DatabaseRequestResult([NotNull] Exception innerException)
        {
            IsSuccess = false;
            InnerException = innerException;
            RecordsAffected = -1;
        }

        public bool IsSuccess { get; }
        public Exception InnerException{ get; }
        public int RecordsAffected { get; internal set; }
        public ColumnDescription[] Headers { get; internal set; }
        public IReadOnlyCollection<object[]> Rows { get; internal set; }
    }
}
