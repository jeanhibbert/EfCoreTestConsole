using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTest.Persistence.Infrastructure.Core
{
    public interface IDefaultContext
    {
        Task<TResult> Read<TResult>(Func<DbContext, Task<TResult>> fn);
        Task<TResult> Write<TResult>(Func<DbContext, Task<TResult>> fn);
        Task<TResult> WriteOptimistically<TResult>(Func<DbContext, Task<TResult>> fn, int maxSaveAttempts);
    }
}
