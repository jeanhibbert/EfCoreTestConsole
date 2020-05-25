using EfCoreTest.Persistence;
using EfCoreTest.Persistence.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EfCoreTest.Tests
{
    public class DefaultDbContextTests
    {
        [Fact]
        public async Task TestReadAndWrite()
        {
            var factory = EntityFramework.DefaultFactory<EfCoreTestContext>(
                new DbContextOptionsBuilder<EfCoreTestContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options, options => new EfCoreTestContext(options));

            var logger = new LoggerFactory().CreateLogger<DefaultDbContext<EfCoreTestContext>>();
            var context = new DefaultDbContext<EfCoreTestContext>(logger, factory);
            var id = 1;
            var added = await context.Write(async db =>
            {
                var result = await db.AddAsync(new Person
                {
                    BusinessEntityId = id,
                    FirstName = "Bob"
                });
                return result.Entity;
            });
            Assert.Equal("Bob", added.FirstName);
            var read = await context.Read(async db => await db.FindAsync<Person>(id));
            Assert.Equal("Bob", read.FirstName);
        }
    }
}
