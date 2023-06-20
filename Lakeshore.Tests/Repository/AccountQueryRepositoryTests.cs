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
    public class AccountQueryRepositoryTests : BaseTest
    {
        private IAccountQueryRepository _repository;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDatabase();

            _repository = new AccountQueryRepository(DbContext);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            DbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetAllAccounts_ReturnsCorrectNumberOfRecords()
        {
            var records = await _repository.GetAllAccount(CancellationToken.None);

            Assert.That(records.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllAccounts_ReturnsCorrectId()
        {
            var records = await _repository.GetAllAccount(CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.Id == "testId1"));
        }

        [Test]
        public async Task GetAllAccounts_ReturnsCorrectLakeshoreCustomerNumber()
        {
            var records = await _repository.GetAllAccount(CancellationToken.None);

            Assert.That(records.Count, Is.GreaterThan(0));

            Assert.IsTrue(records.Any(q => q.Lakeshore_Customer_Number__c == 10));
        }

    }
}
