using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("operationsAPITb")]
    public class OperationsAPI
    {
        [Key]
        public int id { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public string description { get; set; }

        [ForeignKey("operApi_id")]
        public ICollection<Service> Services { get; set; }
    }
}
