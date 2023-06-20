using Lakeshore.Domain.SalesAccountRepository;
using Lakeshore.Domain.UserRepository;
using Lakeshore.Infrastructure.SalesAccount;
using Lakeshore.Infrastructure.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Tests.Repository
{
    [TestFixture]
    public class UserQueryRepositoryTests : BaseTest
    {
        private IUserQueryRepository _repository;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDatabase();

            _repository = new UserQueryRepository(DbContext);
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            DbContext.Database.EnsureDeleted();
        }
        [Test]
        public async Task GetAllUser_ReturnsCorrectRecordCount()
        {
            var records = await _repository.GetUserId("test email1", CancellationToken.None);

            Assert.IsNotEmpty(records);
        }
        [Test]
        public async Task GetAllSalesAccountUpsert_ReturnsCorrectUserId()
        {
            var records = await _repository.GetUserId("test email2", CancellationToken.None);

            Assert.AreEqual("testId2", records);
        }
    }
}
