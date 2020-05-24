using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreTest.Persistence.Infrastructure
{
    public interface IDbContextFactory
    {
        IDbContextWriteable GetDbContextWriteable();
        IDbContextReadonly GetDbContextReadonly();
    }

    public class DbContextFactory : IDbContextFactory
    {

        public IDbContextReadonly GetDbContextReadonly()
        {
            var context = new EfCoreTestContextModel(null);
            // TODO
            return context as IDbContextReadonly;
        }

        public IDbContextWriteable GetDbContextWriteable()
        {
            var context = new EfCoreTestContextModel(null);
            // TODO
            return context as IDbContextWriteable;
        }
    }
}
