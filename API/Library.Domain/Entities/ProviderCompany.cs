using Library.Domain.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
	[Table("mainCmpyCodeProvidersTb")]
	public class ProviderCompany
    {
		[Key]
		public int id { get; set; }
		[Required(ErrorMessage = Constants.ErrorMessageRequired)]
		public int mainCom_id { get; set; }
		[Required]
		public int provider_id { get; set; }
		public string codeNo { get; set; }
		[Required]
		public string host { get; set; }
		[Required]
		[RegularExpression(@"^[1-9]{1}[0-9]{1,5}$",ErrorMessage ="Characters are not allowed.")]
		public string port { get; set; }
		[Required]
		public string linkSuffix { get; set; }
		public bool is_active { get; set; } = true;

		[ForeignKey("mainCom_id")]
		public Company Company { get; set; }
		[ForeignKey("provider_id")]
		public Provider Provider { get; set; }
	}
}
