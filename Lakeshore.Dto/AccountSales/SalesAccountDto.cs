using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Dto.AccountSales
{

    public class SalesAccountDto
    {
        public List<Accounts>? CloudSalesTransactions { get; set; }
    }
    public class Accounts
    {
        public string? ShipToParty { get; set; } = string.Empty;
        public string? SalesRep { get; set; } = string.Empty;
        public string? SalesRepEmail { get; set; }
        public string? Catalog { get; set; }
        public decimal? SalesDistrict { get; set; }
        public decimal? MTDSales { get; set; }
        public decimal? YTDSales { get; set; }
        public decimal? PreviousYearCurrentMonthSales { get; set; }
        public decimal? PreviousYearToDateSales { get; set; }
        public decimal? PreviousYearSales { get; set; }
        public decimal? RollingCurrentYearSales { get; set; }
        public decimal? RollingPreviousYearSales { get; set; }
        public string? ShipToPartyName { get; set; }
        public string? ShipToPartyPhone { get; set; }
        public string? SoldToPartyCity { get; set; }
        public string? SoldToPartyCountry { get; set; }
        public string? SoldToPartyPostalCode { get; set; }
        public string? SoldToPartyRegion { get; set; }
        public string? SoldToPartyStreet { get; set; }
        public string? SoldToPartyStreet2 { get; set; }
        public string? SoldToParty { get; set; }
        public string? ShipToPartyCity { get; set; }
        public string? ShipToPartyCountry { get; set; }
        public string? ShipToPartyPostalCode { get; set; }
        public string? ShipToPartyRegion { get; set; }
        public string? ShipToPartyStreet { get; set; }
        public string? ShipToPartyStreet2 { get; set; }
        public string? FreightTerms { get; set; }
        public string? Type { get; set; }
        public bool MerchCertAccum { get; set; }
        public decimal? MerchCertAmount { get; set; }
        public bool eCustomer { get; set; }
        public bool GSAAcount { get; set; }
        public decimal? MTDSalesSoldTo { get; set; }
        public decimal? YTDSalesSoldTo { get; set; }
        public decimal? PreviousYearCurrentMonthSalesSoldTo { get; set; }
        public decimal? PreviousYearToDateSalesSoldTo { get; set; }
        public decimal? PreviousYearSalesSoldTo { get; set; }
        public decimal? CurrentYearSalesSoldTo { get; set; }
        public decimal? RollingPreviousYearSalesSoldTo { get; set; }
        public decimal? CurrentQuarterToDateSales { get; set; }
        public decimal? PreviousQuarterSales { get; set; }
        public decimal? CurrentQuarterPreviousYearSales { get; set; }
        public decimal? PreviousQuarterPreviousYearSales { get; set; }
        public bool PORequired { get; set; }
        public bool HardCopyofPO { get; set; }

    }
}




