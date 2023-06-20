using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Domain.Models
{
    public class Account : Entity
    {
        public string? Id { get; set; }
        public decimal? Lakeshore_Customer_Number__c { get; set; }
        public string? OwnerId { get; set; }
        public string? Billing_Status__c { get; set; }
        public string? ParentId { get; set; }
        public string? MDR_PID__c { get; set; }
        public string? MDR_Parent_PID__c { get; set; }
        public decimal? MDR_Enrollment__c { get; set; }
        public decimal? Flex_Space_Approx_YTD__c { get; set; }
        public string? Acct_Owner_IP__c { get; set; }
        public decimal? InfTod_Approx_YTD__c { get; set; }
        public decimal? Flex_Space_Approx_LYTD__c { get; set; }
        public string? Description { get; set; }
    }
}
