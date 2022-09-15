using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("providerServicesTb")]
    public class ProviderServices
    {
		[Key]
		public int id { get; set; }
		public int provider_id { get; set; }
		public int service_id { get; set; }
		[ForeignKey("Company")]
		public int mainCom_id { get; set; }
		public string providerServiceNo { get; set; }
		public int priority_number { get; set; }
		public string function_link { get; set; }
		public decimal servicePrice { get; set; }
		public decimal sellingPrice { get; set; }
		[Display(AutoGenerateField = false)]
		public bool is_active { get; set; }
		[Display(AutoGenerateField = false)]
		public int created_by { get; set; }
		[Display(AutoGenerateField = false)]
		public DateTime created_in { get; set; }

		[ForeignKey("provider_id")]
		public Provider Provider { get; set; }
		[ForeignKey("service_id")]
		public Service Service { get; set; }
		public Company Company { get; set; }
	}
}
