using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakeshore.Domain.Models
{
    public class AccountUpsert : Entity
    {
        public string? AccountNumber { get; set; }
        public string? Billing_Status__c { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingCountry { get; set; }
        public string? BillingPostalCode { get; set; }
        public string? BillingState { get; set; }
        public string? BillingStreet { get; set; }
        public string? Billing_County__c { get; set; }
        public string? Shipping_County__c { get; set; }
        public decimal? Curr_MTD_Sales__c { get; set; }
        public decimal? Curr_YTD_Sales__c { get; set; }
        public string? Id{ get; set; }
        public decimal? Lakeshore_Customer_Number__c { get; set; }
        public string? Lakeshore_Terms__c { get; set; }
        public decimal? Llm_Territory_Number__c { get; set; }
        public string? Name { get; set; }
        public string? OwnerId { get; set; }
        public string? ParentId { get; set; }
        public string? Phone { get; set; }
        public decimal? Previous_YCM_Sales__c{ get; set; }
        public decimal? Previous_Year_Sales__c { get; set; }
        public decimal? Previous_YTD_Sales__c { get; set; }
        public string? RecordTypeId { get; set; }
        public decimal? Rolling_Current_Year_Sales__c { get; set; }
        public decimal? Rolling_Previous_Year_Sales__c { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingCountry { get; set; }
        public string? ShippingPostalCode { get; set; }
        public string? ShippingState { get; set; }
        public string? ShippingStreet { get; set; }
        public string? Site { get; set; }
        public string? Type { get; set; }
        public string? Error { get; set; }
        public string? MDR_PID__c { get; set; }
        public string? MDR_Parent_PID__c { get; set; }
        public decimal? MDR_Enrollment__c { get; set; }
        public decimal? Flex_Space_Approx_YTD__c { get; set; }
        public string? Acct_Owner_IP__c { get; set; }
        public decimal? InfTod_Approx_YTD__c { get; set; }
        public decimal? Flex_Space_Approx_LYTD__c{ get; set; }
        public decimal? BT_Curr_MTD_Sales__c { get; set; }
        public decimal? BT_Curr_YTD_Sales__c { get; set; }
        public decimal? BT_Prev_MTD_Sales__c { get; set; }
        public decimal? BT_Prev_YTD_Sales__c { get; set; }
        public decimal? BT_Prev_Year_Sales__c { get; set; }
        public decimal? BT_Rolling_Curr_Year_Sales__c { get; set; }
        public decimal? BT_Rolling_Prev_Year_Sales__c { get; set; }
        public decimal? Current_Quarter_to_Date_Sales__c { get; set; }
        public decimal? Current_Quarter_Previous_Year_Sales__c { get; set; }
        public decimal? Previous_Quarter_Previous_Year_Sales__c { get; set; }
        public decimal? Previous_Quarter_Sales__c { get; set; }
        public decimal? Merch_Cert_Amount__c { get; set; }
        public bool? Merch_Cert_Accum__c { get; set; }
        public bool? Hard_Copy_of_PO__c { get; set; }
        public bool? PO_Required__c { get; set; }
        public bool? ECustomer_c { get; set; }
        public bool? GSA_Account__c { get; set; }

        public AccountUpsert(string? accountNumber, string? billing_Status__c, string? billingCity, string? billingCountry, string? billingPostalCode, string? billingState, string? billingStreet,
            string? billing_County__c, string? shipping_County__c, decimal? curr_MTD_Sales__c, decimal? curr_YTD_Sales__c, string? id,
            decimal? lakeshore_Customer_Number__c, string? lakeshore_Terms__c, decimal? llm_Territory_Number__c, string? name, string? ownerId, string? parentId, 
            string? phone, decimal? previous_YCM_Sales__c, decimal? previous_Year_Sales__c, decimal? previous_YTD_Sales__c, string? recordTypeId, decimal? rolling_Current_Year_Sales__c, 
            decimal? rolling_Previous_Year_Sales__c, string? shippingCity, string? shippingCountry, string? shippingPostalCode, string? shippingState, string? shippingStreet, string? site, 
            string? type, string? error, string? mDR_PID__c, string? mDR_Parent_PID__c, decimal? mDR_Enrollment__c, decimal? flex_Space_Approx_YTD__c, string? acct_Owner_IP__c, 
            decimal? infTod_Approx_YTD__c, decimal? flex_Space_Approx_LYTD__c, decimal? bT_Curr_MTD_Sales__c, decimal? bT_Curr_YTD_Sales__c,decimal? bT_Prev_MTD_Sales__c,
            decimal? bT_Prev_YTD_Sales__c, decimal? bT_Prev_Year_Sales__c, decimal? bT_Rolling_Curr_Year_Sales__c, decimal? bT_Rolling_Prev_Year_Sales__c, decimal? current_Quarter_to_Date_Sales__c, 
            decimal? current_Quarter_Previous_Year_Sales__c, decimal? previous_Quarter_Previous_Year_Sales__c, decimal? previous_Quarter_Sales__c, decimal? merch_Cert_Amount__c,
             bool? merch_Cert_Accum__c, bool? hard_Copy_of_PO__c, bool? pO_Required__c, bool? eCustomer_c, bool? gSA_Account__c)
        {
            AccountNumber = accountNumber;
            Billing_Status__c = billing_Status__c;
            BillingCity = billingCity;
            BillingCountry = billingCountry;
            BillingPostalCode = billingPostalCode;
            BillingState = billingState;
            BillingStreet = billingStreet;
            Billing_County__c = billing_County__c;
            Shipping_County__c = shipping_County__c;
            Curr_MTD_Sales__c = curr_MTD_Sales__c;
            Curr_YTD_Sales__c = curr_YTD_Sales__c;
            Id = id;
            Lakeshore_Customer_Number__c = lakeshore_Customer_Number__c;
            Lakeshore_Terms__c = lakeshore_Terms__c;
            Llm_Territory_Number__c = llm_Territory_Number__c;
            Name = name;
            OwnerId = ownerId;
            ParentId = parentId;
            Phone = phone;
            Previous_YCM_Sales__c = previous_YCM_Sales__c;
            Previous_Year_Sales__c = previous_Year_Sales__c;
            Previous_YTD_Sales__c = previous_YTD_Sales__c;
            RecordTypeId = recordTypeId;
            Rolling_Current_Year_Sales__c = rolling_Current_Year_Sales__c;
            Rolling_Previous_Year_Sales__c = rolling_Previous_Year_Sales__c;
            ShippingCity = shippingCity;
            ShippingCountry = shippingCountry;
            ShippingPostalCode = shippingPostalCode;
            ShippingState = shippingState;
            ShippingStreet = shippingStreet;
            Site = site;
            Type = type;
            Error = error;
            MDR_PID__c = mDR_PID__c;
            MDR_Parent_PID__c = mDR_Parent_PID__c;
            MDR_Enrollment__c = mDR_Enrollment__c;
            Flex_Space_Approx_YTD__c = flex_Space_Approx_YTD__c;
            Acct_Owner_IP__c = acct_Owner_IP__c;
            InfTod_Approx_YTD__c = infTod_Approx_YTD__c;
            Flex_Space_Approx_LYTD__c = flex_Space_Approx_LYTD__c;
            BT_Curr_MTD_Sales__c = bT_Curr_MTD_Sales__c;
            BT_Curr_YTD_Sales__c = bT_Curr_YTD_Sales__c;
            BT_Prev_MTD_Sales__c = bT_Prev_MTD_Sales__c;
            BT_Prev_YTD_Sales__c = bT_Prev_YTD_Sales__c;
            BT_Prev_Year_Sales__c = bT_Prev_Year_Sales__c;
            BT_Rolling_Curr_Year_Sales__c = bT_Rolling_Curr_Year_Sales__c;
            BT_Rolling_Prev_Year_Sales__c = bT_Rolling_Prev_Year_Sales__c;
            Current_Quarter_to_Date_Sales__c = current_Quarter_to_Date_Sales__c;
            Current_Quarter_Previous_Year_Sales__c = current_Quarter_Previous_Year_Sales__c;
            Previous_Quarter_Previous_Year_Sales__c = previous_Quarter_Previous_Year_Sales__c;
            Previous_Quarter_Sales__c = previous_Quarter_Sales__c;
            Merch_Cert_Amount__c = merch_Cert_Amount__c;
            Merch_Cert_Accum__c = merch_Cert_Accum__c;
            Hard_Copy_of_PO__c = hard_Copy_of_PO__c;
            PO_Required__c = pO_Required__c;
            ECustomer_c = eCustomer_c;
            GSA_Account__c = gSA_Account__c;
        }

        public static AccountUpsert CreateAccount(string? AccountNumber, string? Billing_Status__c, string? BillingCity, string? BillingCountry, string? BillingPostalCode, string? BillingState, 
            string? BillingStreet, string? Billing_County__c, 
            string? Shipping_County__c, decimal? Curr_MTD_Sales__c, decimal? Curr_YTD_Sales__c,string? Id, 
            decimal? Lakeshore_Customer_Number__c, string? Lakeshore_Terms__c, decimal? llm_Territory_Number__c, string? Name,
            string? OwnerId, string? ParentId, string? Phone, decimal? Previous_YCM_Sales__c, decimal? Previous_Year_Sales__c, 
            decimal? Previous_YTD_Sales__c, string? RecordTypeId, decimal? Rolling_Current_Year_Sales__c, decimal? Rolling_Previous_Year_Sales__c, 
            string? ShippingCity, string? ShippingCountry, string? ShippingPostalCode, string? ShippingState, string? ShippingStreet, string? Site,
            string? Type, string? Error, string? MDR_PID__c, string? MDR_Parent_PID__c, decimal? MDR_Enrollment__c, decimal? Flex_Space_Approx_YTD__c,
            string? Acct_Owner_IP__c, decimal? InfTod_Approx_YTD__c, decimal? Flex_Space_Approx_LYTD__c,
            decimal? BT_Curr_MTD_Sales__c, decimal? BT_Curr_YTD_Sales__c, decimal? BT_Prev_MTD_Sales__c,
            decimal? BT_Prev_YTD_Sales__c, decimal? BT_Prev_Year_Sales__c, decimal? BT_Rolling_Curr_Year_Sales__c, decimal? BT_Rolling_Prev_Year_Sales__c, decimal? Current_Quarter_to_Date_Sales__c,
            decimal? Current_Quarter_Previous_Year_Sales__c, decimal? Previous_Quarter_Previous_Year_Sales__c, decimal? Previous_Quarter_Sales__c, decimal? Merch_Cert_Amount__c,
             bool? Merch_Cert_Accum__c, bool? Hard_Copy_of_PO__c, bool? PO_Required__c, bool? ECustomer_c, bool? GSA_Account__c)
        {
            // create new Account record
            var account = new AccountUpsert(AccountNumber, Billing_Status__c, BillingCity, BillingCountry, BillingPostalCode, BillingState, BillingStreet, 
                Billing_County__c, Shipping_County__c, Curr_MTD_Sales__c, Curr_YTD_Sales__c, Id, Lakeshore_Customer_Number__c, Lakeshore_Terms__c,
                llm_Territory_Number__c, Name, OwnerId, ParentId, Phone, Previous_YCM_Sales__c, Previous_Year_Sales__c, Previous_YTD_Sales__c, RecordTypeId, 
                Rolling_Current_Year_Sales__c, Rolling_Previous_Year_Sales__c, ShippingCity, ShippingCountry, ShippingPostalCode, ShippingState, ShippingStreet, 
                Site, Type, Error, MDR_PID__c, MDR_Parent_PID__c, MDR_Enrollment__c, Flex_Space_Approx_YTD__c, Acct_Owner_IP__c, InfTod_Approx_YTD__c, Flex_Space_Approx_LYTD__c,
                BT_Curr_MTD_Sales__c, BT_Curr_YTD_Sales__c, BT_Prev_MTD_Sales__c, BT_Prev_YTD_Sales__c, BT_Prev_Year_Sales__c, BT_Rolling_Curr_Year_Sales__c, BT_Rolling_Prev_Year_Sales__c,
                Current_Quarter_to_Date_Sales__c, Current_Quarter_Previous_Year_Sales__c, Previous_Quarter_Previous_Year_Sales__c, Previous_Quarter_Sales__c, Merch_Cert_Amount__c,
                Merch_Cert_Accum__c, Hard_Copy_of_PO__c, PO_Required__c, ECustomer_c, GSA_Account__c);
            // if we need to trigger some event when creating a new Account record add it here.

            return account;
        }

    }
}
