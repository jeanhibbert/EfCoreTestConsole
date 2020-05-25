namespace EfCoreTest.Persistence.Infrastructure
{
    public interface IEfCoreTestContextFactory
    {
        IEfCoreTestContextWriteable GetDbContextWriteable();
        IEfCoreTestContextReadonly GetDbContextReadonly();
    }

    public class EfCoreTestContextFactory : IEfCoreTestContextFactory
    {

        public IEfCoreTestContextReadonly GetDbContextReadonly()
        {
            var context = new EfCoreTestContext();
            context.ChangeTracker.AutoDetectChangesEnabled = false;
            context.ChangeTracker.LazyLoadingEnabled = false;
            context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
            return new EfCoreTestContextModel(context) as IEfCoreTestContextReadonly;
        }

        public IEfCoreTestContextWriteable GetDbContextWriteable()
        {
            var context = new EfCoreTestContext();
            context.ChangeTracker.LazyLoadingEnabled = false;
            return new EfCoreTestContextModel(context) as IEfCoreTestContextWriteable;
        }
    }
}
