using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("permissionRoleTb")]
    public class PermissionRole
    {
        [Key]
        public int id { get; set; }
        public int role_id { get; set; }
        public int permission_id { get; set; }
        [Display(AutoGenerateField = false)]
        public int created_by { get; set; }
        [Display(AutoGenerateField = false)]
        public DateTime created_in { get; set; }

        [ForeignKey("role_id")]
        public Role Role { get; set; }
        [ForeignKey("permission_id")]
        public Permission Permission { get; set; }
    }
}
