using Library.Domain.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
	[Table("providerTb")]
	public class Provider
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		[Required(ErrorMessage = Constants.ErrorMessageRequired), MaxLength(50), MinLength(4)]
		public string fullName { get; set; }
		[MaxLength(500), MinLength(20)]
		public string description { get; set; }
		public string address { get; set; }
		[Phone]
		public string mobileNum { get; set; }
		[Phone]
		public string phoneNum { get; set; }
		[Url, MaxLength(250)]
		public string accessServiceLink { get; set; }
		public string userName { get; set; }
		[DataType(DataType.Password)]
		public string password { get; set; }
		public string accountNumber { get; set; }
		public decimal? theBalance { get; set; }
		public DateTime? subscription_date { get; set; }
		public bool is_active { get; set; }
		public int? created_by { get; set; }
		public DateTime? created_in { get; set; }

		public ICollection<ProviderCompany> ProvidersCompanies { get; set; }
		[ForeignKey("provider_id")]
		public ICollection<TransactionStatus> Transactions { get; set; }
	}
}
