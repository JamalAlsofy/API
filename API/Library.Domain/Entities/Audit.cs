using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("auditTb")]
    public class Audit
    {
        [Key]
        public long id { get; set; }
        public DateTime theDate { get; set; }
        public int user_id { get; set; }
        public int operApi_id { get; set; }
        public string theContent { get; set; }
        public DateTime created_in { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }
        [ForeignKey("operApi_id")]
        public OperationsAPI OperationsAPI { get; set; }
    }
}
