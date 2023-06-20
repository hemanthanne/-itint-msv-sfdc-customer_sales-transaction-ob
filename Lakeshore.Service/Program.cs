using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Lakeshore.Kafka.Client.Implementation;
using Lakeshore.Kafka.Client.Interfaces;
using Lakeshore.Kafka.Client;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Lakeshore.Infrastructure.DomainEventsDispatching;
using Lakeshore.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Lakeshore.Infrastructure.EntityModelConfiguration;
using Lakeshore.Domain;
using Lakeshore.Application.ConsumerService;
using Lakeshore.Domain.SalesAccountRepository;
using Lakeshore.Infrastructure.SalesAccount;
using Lakeshore.Domain.AccountRepository;
using Lakeshore.Infrastructure.Accounts;
using Lakeshore.Domain.UserRepository;
using Lakeshore.Infrastructure.User;
using Lakeshore.Domain.RecordTypeRepository;
using Lakeshore.Infrastructure.RecordType;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(KafkaMessageConsumedHandler).Assembly));

// Add Repositories
builder.Services.AddTransient<ISalesAccountUpsertCommandRepository, SalesAccountUpsertCommandRepository>();
builder.Services.AddTransient<ISalesAccountUpsertQueryRepository, SalesAccountUpsertQueryRepository>();

builder.Services.AddTransient<IAccountUpsertCommandRepository, AccountUpsertCommandRepository>();
builder.Services.AddTransient<IAccountUpsertQueryRepository, AccountUpsertQueryRepository>();

builder.Services.AddTransient<ISalesAccountQueryRepository, SalesAccountQueryRepository>();

builder.Services.AddTransient<IAccountQueryRepository, AccountQueryRepository>();

builder.Services.AddTransient<IUserQueryRepository, UserQueryRepository>();

builder.Services.AddTransient<IRecordTypeQueryRepository, RecordTypeQueryRepository>();

// Add Domain Events
builder.Services.AddTransient<IDomainEventsAccessor,DomainEventsAccessor>();

// Add Unit of Work
builder.Services.AddTransient<ICommandUnitOfWork,CommandUnitOfWorkNoProducer>();

// Add Kafka Producer
builder.Services.Configure<ProducerSettings>(configuration.GetSection(nameof(ProducerSettings)));
builder.Services.AddScoped<IKafkaProducerClient, KafkaProducerClient>();

// Add Kafka Consumer
builder.Services.Configure<ConsumerSettings>(configuration.GetSection(nameof(ConsumerSettings)));
builder.Services.AddScoped<IKafkaConsumerClient, KafkaConsumerClient>();

// Add Helper Methods

// Add DynamoDB Key-Store
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddKeyStore(configuration);

// Add DB Context
builder.Services.AddDbContext<SalesAccountContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"), sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    });
});

// Add Consumer Service
builder.Services.AddHostedService<ConsumerService>();

// Add Serilog
var logger = new LoggerConfiguration()
    // Read from appsettings.json
    .ReadFrom.Configuration(configuration)
    // Create the actual logger
    .CreateLogger();
builder.Host.UseSerilog(logger);

// Add Controllers and Setup
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapHealthChecks("/healthz");

app.MapControllers();

app.Run();
