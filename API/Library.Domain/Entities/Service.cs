using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("serviceTb")]
    public class Service
    {
        [Key]
		public int id { get; set; }
		public int operApi_id { get; set; }
		public int catg_id { get; set; }
		public string nameAr { get; set; }
		public string nameEn { get; set; }
		public string serviceNo { get; set; }
		public string description { get; set; }
		public byte servicePriceStatus { get; set; }
		public decimal servicePrice { get; set; }
		public decimal sellingPrice { get; set; }
		[Display(AutoGenerateField = false)]
		public bool is_active { get; set; }
		[Display(AutoGenerateField = false)]
		public int created_by { get; set; }
		[Display(AutoGenerateField = false)]
		public DateTime created_in { get; set; }

		public ICollection<TransactionStatus> Transactions { get; set; }
	}
}
