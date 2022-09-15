using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("paymentTypeTb")]
    public class PaymentType
    {
        [Key]
        public int id { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }

        [ForeignKey("paymentType_id")]
        public ICollection<TransactionStatus> Transactions { get; set; }

    }
}
