using Lakeshore.Domain.SalesAccountRepository;
using Lakeshore.Infrastructure.SalesAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Tests.Repository
{
    [TestFixture]
    public class SalesAccountUpsertQueryRepositoryTests : BaseTest
    {
        private ISalesAccountUpsertQueryRepository _repository;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDatabase();

            _repository = new SalesAccountUpsertQueryRepository(DbContext);
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            DbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetAllSalesAccountUpsert_ReturnsCorrectNumberOfRecords()
        {
            var records = await _repository.GetAllSalesAccount(CancellationToken.None);

            Assert.That(records.Count, Is.EqualTo(4));
        }
        [Test]
        public async Task GetAllSalesAccountUpsert_ReturnsCorrectAcctCatTerritory()
        {
            var records = await _repository.GetAllSalesAccount(CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.AccountCategoryTerritory == "test accountCategoryTerritory3"));
        }
        [Test]
        public async Task GetAllSalesAccountUpsert_ReturnsCorrectYTDSales()
        {
            var records = await _repository.GetAllSalesAccount(CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.YtdSales == 90));
        }
    }
}
