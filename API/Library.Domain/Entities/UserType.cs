using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("userTypeTb")]
    public class UserType
    {
        [Key]
        public int id { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public bool is_active { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
