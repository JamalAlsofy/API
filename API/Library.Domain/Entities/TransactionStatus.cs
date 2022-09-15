using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("transactionStatusTb")]
    public class TransactionStatus
    {
		[Key]
		public long id { get; set; }
		public DateTime dateRequest { get; set; }
		public decimal amount { get; set; }
		public int service_id { get; set; }
		public int customer_id { get; set; }
		public int? provider_id { get; set; }
		public int paymentType_id { get; set; }
		public string target_number { get; set; }
		public string custReference { get; set; }
		public string myReference { get; set; }
		public string theStatement { get; set; }
		public string providerReference { get; set; }
		public byte resultStatus { get; set; }
		public string theResult { get; set; }
		public DateTime dateResponse { get; set; }
		public string referenceNo { get; set; }
		[Display(AutoGenerateField = false)]
		public DateTime created_in { get; set; }

		[ForeignKey("service_id")]
		public Service Service { get; set; }
		[ForeignKey("customer_id")]
		public CustomerAccounts CustomerAccount { get; set; }
	}
}
