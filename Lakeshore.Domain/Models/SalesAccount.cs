using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Domain.Models
{
    public class SalesAccount
    {
        public string? Id { get; set; }
        public string? OwnerId { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedById { get; set; }
        public DateTime? SystemModstamp { get; set; }
        public DateTime? LastViewedDate { get; set; }
        public DateTime? LastReferencedDate { get; set; }
        public string? Acct_Cat_Territory__c { get; set; }
        public decimal? Lakeshore_Customer_Number_del__c { get; set; }
        public decimal? Territory__c { get; set; }
        public decimal? MTD_Sales__c { get; set; }
        public decimal? YTD_Sales__c { get; set; }
        public decimal? Previous_Year_Current_Month__c { get; set; }
        public decimal? Previous_Year_To_Date__c { get; set; }
        public decimal? Previous_Year_Sales__c { get; set; }
        public string? Account_ID__c { get; set; }
        public DateTime? Report_Month__c { get; set; }
        public decimal? Rolling_Current_Year_Sales__c { get; set; }
        public decimal? Rolling_Previous_Year_Sales__c { get; set; }
        public string? Catalog__c { get; set; }
        public decimal? Yearly_Percent_Diff__c { get; set; }
        public decimal? Monthly_Percent_Diff__c { get; set; }
        public string? Customer_Number__c { get; set; }
        public DateTime? Last_Modified_Date__c { get; set; }
        public string? Billing_Postal_Code__c { get; set; }
        public string? EAM_Zone__c { get; set; }
        public decimal? zEAM_Visibility__c { get; set; }

    }
}
