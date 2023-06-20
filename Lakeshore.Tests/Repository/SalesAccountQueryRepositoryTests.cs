using Lakeshore.Domain.AccountRepository;
using Lakeshore.Domain.SalesAccountRepository;
using Lakeshore.Infrastructure.Accounts;
using Lakeshore.Infrastructure.SalesAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Tests.Repository
{
    [TestFixture]
    public class SalesAccountQueryRepositoryTests : BaseTest
    {
        private ISalesAccountQueryRepository _repository;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDatabase();

            _repository = new SalesAccountQueryRepository(DbContext);
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            DbContext.Database.EnsureDeleted();
        }
        [Test]
        public async Task GetAllSalesAccount_ReturnsCorrectNumberOfRecords()
        {
            var records = await _repository.GetSalesAccount(CancellationToken.None);

            Assert.That(records.Count, Is.EqualTo(3));
        }
        [Test]
        public async Task GetAllAccounts_ReturnsCorrectAcctCatTerritory()
        {
            var records = await _repository.GetSalesAccount(CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.Acct_Cat_Territory__c == "test1-Elementary-test1"));
        }
        [Test]
        public async Task GetAllAccounts_ReturnsCorrectId()
        {
            var records = await _repository.GetSalesAccount(CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.Id == "test id1"));
        }
    }
}
