using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreTest.Persistence.Infrastructure
{
    public class EfCoreTestContextModel : ContextModelBase
    {
        private readonly EfCoreTestContext _efCoreTestContext;

        public EfCoreTestContextModel(EfCoreTestContext efCoreTestContext) : base(efCoreTestContext)
        {
            _efCoreTestContext = efCoreTestContext;
        }



    }
}
