using SomeAspProject.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeAspProject.Services.Database
{
    public interface IDatabaseService :IDisposable
    {
        Task<DatabaseRequestResult> SendRequestAsync(string request);
    }
}
