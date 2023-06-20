using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Lakeshore.Tests.Repository
{
    public abstract class BaseTest
    {
        protected readonly DbContextOptions<SalesAccountContext> DbContextOptions;
        protected SalesAccountContext DbContext;
        protected Mock<ILogger> LoggerMock;

        protected BaseTest()
        {
            DbContextOptions = new DbContextOptionsBuilder<SalesAccountContext>()
                .UseInMemoryDatabase(databaseName: "SalesAccount")
                .Options;

            DbContext = new SalesAccountContext(DbContextOptions);

            LoggerMock = new Mock<ILogger>();
        }
        protected void SetupFixture()
        {
            LoggerMock = new Mock<ILogger>();

            LoggerMock.Setup(m => m.LogInformation(It.IsAny<string>())).Verifiable();
            LoggerMock.Setup(m => m.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
        }
        protected void SeedDatabase()
        {
            DbContext.Database.EnsureCreated();

            SeedSalesAccountsUpsert();
            SeedSalesAccount();
            SeedAccountUpsert();
            SeedAccount();
            SeedUser();
            SeedRecordType();

            DbContext.SaveChanges();
        }
        private void SeedSalesAccountsUpsert()
        {
            var salesAccountUpsert = new List<SalesAccountUpsert>
            {
                new SalesAccountUpsert("test accountId1","test accountCategoryTerritory1","test id1",2,"test name1","test ownerId1",4,2,9,3,1,8,45,"test error1"),
                new SalesAccountUpsert("test accountId2","test accountCategoryTerritory2","test id2",7,"test name2","test ownerId2",1,7,9,3,4,9,27,"test error2"),
                new SalesAccountUpsert("test accountId3","test accountCategoryTerritory3","test id3",0,"test name3","test ownerId3",9,4,2,9,1,8,94,"test error3"),
                new SalesAccountUpsert("test accountId4","test accountCategoryTerritory4","test id4",56,"test name4","test ownerId4",6,2,1,6,3,8,90,"test error4"),
            };

            DbContext.SalesAccountsUpsert.AddRange(salesAccountUpsert);
        }
        private void SeedSalesAccount()
        {
            var salesAccount = new List<SalesAccount>
            {
                new SalesAccount(){Acct_Cat_Territory__c = "test1-Elementary-test1" , Id = "test id1"},
                new SalesAccount(){Acct_Cat_Territory__c = "test2-Elementary-test2" , Id = "test id2"},
                new SalesAccount(){Acct_Cat_Territory__c = "test3-Elementary-test3" , Id = "test id3"}
            };

            DbContext.SalesAccount.AddRange(salesAccount);
        }
        private void SeedAccountUpsert()
        {
            var accountUpsert = new List<AccountUpsert>
            {
                new AccountUpsert("test accountNumber","test billingstatus","test billingcity","test billingcountry","billingPostalCode","","","","",1,3,"",4,"",32,"","","","",3,4,5,"",3,2,"","","","","","","","","","",67,21,"",22,21,12,34,54,5,4,5,6,12,13,23,12,12,true,true,true,true,true)
            };

            DbContext.AccountUpsert.AddRange(accountUpsert);
        }
        private void SeedAccount()
        {
            var account = new List<Account>
            {
                new Account(){Id = "testId1",Lakeshore_Customer_Number__c= 10,OwnerId = "test ownerId1",Billing_Status__c="test billingstatus",ParentId="parentid",MDR_Parent_PID__c="",MDR_PID__c="",MDR_Enrollment__c=12,Flex_Space_Approx_YTD__c=12,Acct_Owner_IP__c="",InfTod_Approx_YTD__c=23,Flex_Space_Approx_LYTD__c=12},
                new Account(){Id = "testId2",Lakeshore_Customer_Number__c= 10,OwnerId = "test ownerId2",Billing_Status__c="test billingstatus",ParentId="parentid",MDR_Parent_PID__c="",MDR_PID__c="",MDR_Enrollment__c=45,Flex_Space_Approx_YTD__c=12,Acct_Owner_IP__c="",InfTod_Approx_YTD__c=23,Flex_Space_Approx_LYTD__c=12}

            };

            DbContext.Account.AddRange(account);
        }
        private void SeedUser()
        {
            var user = new List<User>
            {
                new User(){Id = "testId1",Email = "test email1"},
                new User(){Id = "testId2",Email = "test email2"}
            };

            DbContext.User.AddRange(user);
        }
        private void SeedRecordType()
        {
            var recordType = new List<RecordType>
            {
                new RecordType(){Id = "testId1",DeveloperName = "test name1"},
                new RecordType(){Id = "testId2",DeveloperName = "test name2"}
            };

            DbContext.RecordType.AddRange(recordType);
        }
    }
}
