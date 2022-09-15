using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("customerAccountsTb")]
    public class CustomerAccounts
    {
		[Key]
		public int id { get; set; }
		public string customerNo { get; set; }
		public string fullName { get; set; }
		public string activity { get; set; }
		public string address { get; set; }
		public string mobileNum { get; set; }
		public string phoneNum { get; set; }
		public string description { get; set; }
		public int user_id { get; set; }
		public string accountNumber { get; set; }
		public decimal theBalance { get; set; }
		public decimal accountLimit { get; set; }
		public DateTime subscription_date { get; set; }
		[Display(AutoGenerateField = false)]
		public byte EStatus { get; set; }
		[Display(AutoGenerateField = false)]
		public int created_by { get; set; }
		[Display(AutoGenerateField = false)]
		public DateTime created_in { get; set; }

		[ForeignKey("user_id")]
		public User User { get; set; }
		public ICollection<TransactionStatus> Transactions { get; set; }
	}
}
