using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("categoriesTb")]
    public class Category
    {
        [Key]
        public int id { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }

        [ForeignKey("catg_id")]
        public ICollection<Service> Services { get; set; }
    }
}
