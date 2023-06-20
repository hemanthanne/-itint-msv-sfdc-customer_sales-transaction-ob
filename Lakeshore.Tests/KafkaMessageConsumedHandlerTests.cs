using Confluent.Kafka;
using Lakeshore.Application.ConsumerService;
using Lakeshore.Domain.AccountRepository;
using Lakeshore.Domain.RecordTypeRepository;
using Lakeshore.Domain.SalesAccountRepository;
using Lakeshore.Domain.UserRepository;
using Lakeshore.Infrastructure;
using Lakeshore.Infrastructure.Accounts;
using Lakeshore.Infrastructure.DomainEventsDispatching;
using Lakeshore.Infrastructure.RecordType;
using Lakeshore.Infrastructure.SalesAccount;
using Lakeshore.Infrastructure.User;
using Lakeshore.Tests.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Tests
{
    [TestFixture]
    public class KafkaMessageConsumedHandlerTests : BaseTest
    {
        private Mock<IMediator> _mediatorMock;
        private Mock<ICommandUnitOfWork> _commandUnitOfWorkMock;
        private Mock<ILogger<KafkaMessageConsumedHandler>> _loggerMock;
        private Mock<ILogger<CommandUnitOfWorkNoProducer>> _loggerCommandUnitOfWorkNoProducer;
        private KafkaMessageConsumedHandler _handler;
        private IDomainEventsAccessor _domainEventsAccessor;


        private ISalesAccountUpsertCommandRepository salesAccountUpsertCommandRepository;
        private ISalesAccountUpsertQueryRepository salesAccountUpsertQueryRepository;
        private ISalesAccountQueryRepository salesAccountQueryRepository;
        private IAccountUpsertCommandRepository accountCommandRepository;
        private IAccountUpsertQueryRepository accountUpsertQueryRepository;
        private IAccountQueryRepository accountQueryRepository;
        private IUserQueryRepository userQueryRepository;
        private IRecordTypeQueryRepository recordTypeQueryRepository;


        [OneTimeSetUp]
        public void Setup()
        {
            // Arrange Database related objects
            SeedDatabase();

            salesAccountUpsertCommandRepository = new SalesAccountUpsertCommandRepository(DbContext);
            salesAccountUpsertQueryRepository = new SalesAccountUpsertQueryRepository(DbContext);
            salesAccountQueryRepository = new SalesAccountQueryRepository(DbContext);
            accountCommandRepository = new AccountUpsertCommandRepository(DbContext);
            accountUpsertQueryRepository = new AccountUpsertQueryRepository(DbContext);
            accountQueryRepository = new AccountQueryRepository(DbContext);
            userQueryRepository = new UserQueryRepository(DbContext);
            recordTypeQueryRepository = new RecordTypeQueryRepository(DbContext);

            // Arrange Unit Of Work
            _mediatorMock = new Mock<IMediator>();
            //_mediatorMock.Setup(m => m.Publish(It.IsAny<SalesforceInventoryRequestGroupedEvent>(), It.IsAny<CancellationToken>()));

          
            var commandUnitOfWork = new CommandUnitOfWorkNoProducer(
                DbContext,
                _domainEventsAccessor,
                _mediatorMock.Object,
                _loggerCommandUnitOfWorkNoProducer.Object);

            _commandUnitOfWorkMock = new Mock<ICommandUnitOfWork>();
            _commandUnitOfWorkMock.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
                // Allow us to defer calling the actual method, until its actually called within our test.
                .Returns(() => commandUnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()));

            // Arrange Command Handler
            _handler = new KafkaMessageConsumedHandler(_loggerMock.Object, 
                _commandUnitOfWorkMock.Object, 
                salesAccountUpsertCommandRepository, 
                salesAccountUpsertQueryRepository,
                salesAccountQueryRepository, 
                accountCommandRepository, 
                accountUpsertQueryRepository,
                accountQueryRepository,
                userQueryRepository, 
                recordTypeQueryRepository
               );
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            DbContext.Database.EnsureDeleted();
        }
    }
}
