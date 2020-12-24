using System;
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
        }

        public bool IsSuccess { get; }
        public Exception InnerException{ get; }

    }
}
