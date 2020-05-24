using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCoreTest.Persistence.Infrastructure
{
    public class EfCoreTestContextModel : ContextModelBase, IEfCoreTestContextReadonly, IEfCoreTestContextWriteable
    {
        private readonly EfCoreTestContext _efCoreTestContext;

        public EfCoreTestContextModel(EfCoreTestContext efCoreTestContext) : base(efCoreTestContext)
        {
            _efCoreTestContext = efCoreTestContext;
        }

        public IQueryable<Person> Persons => _efCoreTestContext.People;

        DbSet<Person> IEfCoreTestContextWriteable.Persons => _efCoreTestContext.People;
    }
}
