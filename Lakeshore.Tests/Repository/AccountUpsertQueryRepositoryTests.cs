using Lakeshore.Domain.AccountRepository;
using Lakeshore.Infrastructure.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Tests.Repository
{
    [TestFixture]
    public class AccountUpsertQueryRepositoryTests : BaseTest
    {
        private IAccountUpsertQueryRepository _repository;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDatabase();

            _repository = new AccountUpsertQueryRepository(DbContext);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            DbContext.Database.EnsureDeleted();
        }
        [Test]
        public async Task GetAllAccountUpsert_ReturnsCorrectNumberOfRecords()
        {
            var records = await _repository.GetAllAccountUpsert(CancellationToken.None);

            Assert.That(records.Count, Is.EqualTo(1));
        }
        [Test]
        public async Task GetAllAccounts_ReturnsCorrectAccountNumber()
        {
            var records = await _repository.GetAllAccountUpsert(CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.AccountNumber == "test accountNumber"));
        }
        [Test]
        public async Task GetAllAccounts_ReturnsCorrectBillingPostalCode()
        {
            var records = await _repository.GetAllAccountUpsert(CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.BillingPostalCode == "billingPostalCode"));
        }
    }
}
