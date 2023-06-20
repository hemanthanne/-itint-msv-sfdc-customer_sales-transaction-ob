using Lakeshore.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Lakeshore.Domain.Models;
using Lakeshore.Dto.AccountSales;
using Lakeshore.Domain.SalesAccountRepository;
using Lakeshore.Domain.AccountRepository;
using Lakeshore.Domain.UserRepository;
using Lakeshore.Domain.RecordTypeRepository;

namespace Lakeshore.Application.ConsumerService
{
    public class KafkaMessageConsumedHandler : INotificationHandler<KafkaMessageConsumedNotification>
    {
        private readonly ILogger<KafkaMessageConsumedHandler> _logger;
        private readonly ICommandUnitOfWork _unitWork;
        private readonly ISalesAccountUpsertCommandRepository _salesAccountUpsertCommandRepository;
        private readonly ISalesAccountUpsertQueryRepository _salesAccountUpsertQueryRepository;
        private readonly ISalesAccountQueryRepository _salesAccountQueryRepository;
        private readonly IAccountUpsertCommandRepository _accountCommandRepository;
        private readonly IAccountUpsertQueryRepository _accountUpsertQueryRepository;
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IRecordTypeQueryRepository _recordTypeQueryRepository;

        public KafkaMessageConsumedHandler(
            ILogger<KafkaMessageConsumedHandler> logger, 
            ICommandUnitOfWork commandUnitOfWork,
            ISalesAccountUpsertCommandRepository salesAccountUpsertCommandRepository,
            ISalesAccountUpsertQueryRepository salesAccountUpsertQueryRepository,
            ISalesAccountQueryRepository salesAccountQueryRepository,
            IAccountUpsertCommandRepository accountCommandRepository,
            IAccountUpsertQueryRepository accountUpsertQueryRepository,
            IAccountQueryRepository accountQueryRepository,
            IUserQueryRepository userQueryRepository,
            IRecordTypeQueryRepository recordTypeQueryRepository
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitWork = commandUnitOfWork ?? throw new ArgumentNullException(nameof(commandUnitOfWork));
            _salesAccountUpsertCommandRepository = salesAccountUpsertCommandRepository ?? throw new ArgumentNullException(nameof(salesAccountUpsertCommandRepository));
            _salesAccountUpsertQueryRepository = salesAccountUpsertQueryRepository ?? throw new ArgumentNullException(nameof(salesAccountUpsertQueryRepository));
            _salesAccountQueryRepository = salesAccountQueryRepository ?? throw new ArgumentNullException(nameof(salesAccountQueryRepository));
            _accountCommandRepository = accountCommandRepository ?? throw new ArgumentNullException(nameof(accountCommandRepository));
            _accountUpsertQueryRepository = accountUpsertQueryRepository ?? throw new ArgumentNullException(nameof(accountUpsertQueryRepository));
            _accountQueryRepository = accountQueryRepository ?? throw new ArgumentNullException(nameof(accountQueryRepository));
            _userQueryRepository = userQueryRepository ?? throw new ArgumentNullException(nameof(userQueryRepository));
            _recordTypeQueryRepository = recordTypeQueryRepository ?? throw new ArgumentNullException(nameof(recordTypeQueryRepository));
        }

        public async Task Handle(KafkaMessageConsumedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Attempting to process message");

            try
            {
      
                var newSalesAccount = notification.Message != null ? JObject.Parse(notification.Message).ToObject<SalesAccountDto>() : null;
                var salesAccountList = _salesAccountUpsertQueryRepository.GetAllSalesAccount(cancellationToken).Result.ToList();
                var accountUpsertList = _accountUpsertQueryRepository.GetAllAccountUpsert(cancellationToken).Result.ToList();
                var salesAccount = _salesAccountQueryRepository.GetSalesAccount(cancellationToken).Result.ToList();
                var accounts = _accountQueryRepository.GetAllAccount(cancellationToken).Result.ToList();

                foreach (var account in newSalesAccount.CloudSalesTransactions)
                {
                    var existingSalesAccount = salesAccountList.FirstOrDefault(x => x.AccountId == account.ShipToParty);
                    var existingAccount = accountUpsertList.FirstOrDefault(x => x.AccountNumber == account.ShipToParty);
                    string accountCategoryTerritory = account.SoldToParty + "-" + account.Catalog + "-" + account.SalesDistrict;
                    string? accountId = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.SoldToParty))?.Id;
                    string? id = salesAccount?.FirstOrDefault(x => !string.IsNullOrEmpty(x.Acct_Cat_Territory__c) && x.Acct_Cat_Territory__c.Equals(accountCategoryTerritory))?.Id;
                    string? ownerId = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.SoldToParty))?.OwnerId;

                    string? billing_status = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.ShipToParty))?.Billing_Status__c;
                    string? parentId = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.ShipToParty))?.ParentId;
                    string? mdr_pid__c = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.ShipToParty))?.MDR_PID__c;
                    string? mdr_parent_pid__c = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.ShipToParty))?.MDR_Parent_PID__c;
                    decimal? mdr_enrollment__c = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.ShipToParty))?.MDR_Enrollment__c;
                    decimal? flex_space_approx_ytd__c = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.ShipToParty))?.Flex_Space_Approx_YTD__c;
                    string? acct_owner_ip__c = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.ShipToParty))?.Acct_Owner_IP__c;
                    decimal? inftod_approx_ytd__c = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.ShipToParty))?.InfTod_Approx_YTD__c;
                    decimal? flex_space_approx_lytd__c = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.ShipToParty))?.Flex_Space_Approx_LYTD__c;
                    string? account_upsert_ownerId = _userQueryRepository.GetUserId(account.SalesRepEmail, cancellationToken).Result;
                    string? recordTypeId = _recordTypeQueryRepository.RecordTypeId("Bart_" + billing_status + "", cancellationToken).Result;
                    string? description = accounts?.FirstOrDefault(x => x.Lakeshore_Customer_Number__c != null && x.Lakeshore_Customer_Number__c == Convert.ToDecimal(account.ShipToParty))?.Description;

                    if (existingSalesAccount == null)
                    {
                        // apply some transformation
                        SalesAccountUpsert salesAccountUpsert = SalesAccountUpsert.CreateSalesAccount(
                           accountId,
                           accountCategoryTerritory,
                           id,
                           account.MTDSales,
                           account.Catalog + "-" + account.SalesDistrict,
                           ownerId,
                           account.PreviousYearCurrentMonthSales,
                           account.PreviousYearSales,
                           account.PreviousYearToDateSales,
                           account.RollingCurrentYearSales,
                           account.RollingPreviousYearSales,
                           account.SalesDistrict,
                           account.YTDSales,
                           ""
                            );

                        _salesAccountUpsertCommandRepository.Add(salesAccountUpsert, cancellationToken);
                    }
                    else
                    {
                        existingSalesAccount.AccountCategoryTerritory = accountCategoryTerritory;
                        existingSalesAccount.Id = id;
                        //existingSalesAccount.LakeshoreCustomerNumber = null;
                        existingSalesAccount.MtdSales = account.MTDSales;
                        existingSalesAccount.Name = account.Catalog + "-" + account.SalesDistrict;
                        existingSalesAccount.OwnerId = ownerId;
                        existingSalesAccount.PrevYearCurrMonth = account.PreviousYearCurrentMonthSales;
                        existingSalesAccount.PrevYearSales = account.PreviousYearSales;
                        existingSalesAccount.PrevYearToDate = account.PreviousYearToDateSales;
                        existingSalesAccount.RollCurrYearSales = account.RollingCurrentYearSales;
                        existingSalesAccount.RollPrevYearSales = account.RollingPreviousYearSales;
                        existingSalesAccount.Territory = account.SalesDistrict;
                        existingSalesAccount.YtdSales = account.YTDSales;

                        _salesAccountUpsertCommandRepository.Update(existingSalesAccount, cancellationToken);
                    }


                    string billingStatus = string.Empty;
                    if (account.ShipToParty != account.SoldToParty)
                        billingStatus = (billing_status == "BillTo" || billing_status == "Multi") ? "Multi" : "ShipTo";
                    else
                        billingStatus = (billing_status == "ShipTo" || billing_status == "Multi") ? "Multi" : "BillTo";


                    // apply some transformation
                    AccountUpsert accnt = AccountUpsert.CreateAccount(
                      account.ShipToParty,
                      billingStatus,
                      account.SoldToPartyCity,
                      account.SoldToPartyCountry,
                      account.SoldToPartyPostalCode,
                      account.SoldToPartyRegion,
                      account.SoldToPartyStreet,
                      "",
                      "",
                      account.MTDSalesSoldTo,
                      account.YTDSalesSoldTo,
                      accountId,
                     Convert.ToDecimal(account.ShipToParty),
                      account.FreightTerms,
                      account.SalesDistrict,
                      account.ShipToPartyName + "-" + account.ShipToParty,
                      account_upsert_ownerId,
                      parentId,
                      account.ShipToPartyPhone,
                      account.PreviousYearCurrentMonthSales,
                      account.PreviousYearSales,
                      account.PreviousYearToDateSales,
                      recordTypeId,
                      account.RollingCurrentYearSales,
                      account.RollingPreviousYearSales,
                      account.ShipToPartyCity,
                      account.ShipToPartyCountry,
                      account.ShipToPartyPostalCode,
                      account.ShipToPartyRegion,
                      account.ShipToPartyStreet,
                      account.ShipToParty,
                      account.Type,
                      "",
                      mdr_pid__c,
                      mdr_parent_pid__c,
                      mdr_enrollment__c,
                      flex_space_approx_ytd__c,
                      acct_owner_ip__c,
                      inftod_approx_ytd__c,
                      flex_space_approx_lytd__c,
                      account.MTDSalesSoldTo,
                      account.YTDSalesSoldTo,
                      account.PreviousYearCurrentMonthSalesSoldTo,
                      account.PreviousYearToDateSalesSoldTo,
                      account.PreviousYearSalesSoldTo,
                      account.RollingCurrentYearSales,
                      account.RollingPreviousYearSales,
                      account.CurrentQuarterToDateSales,
                      account.CurrentQuarterPreviousYearSales,
                      account.PreviousQuarterPreviousYearSales,
                      account.PreviousQuarterSales,
                      account.MerchCertAmount,
                      account.MerchCertAccum,
                      account.HardCopyofPO,
                      account.PORequired,
                      account.eCustomer,
                      account.GSAAcount
                      );

              await _accountCommandRepository.Add(accnt, cancellationToken);
                }

                await _unitWork.SaveChangesAsync(cancellationToken);

                _logger.LogInformation("Successfully processed and saved message in database");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing message: ");
            }
        }
    }
}
