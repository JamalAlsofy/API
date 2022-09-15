using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
	[Table("userPermissionTb")]
	public class UserPermissions
    {
		[Key]
		public int id { get; set; }
		public int user_id { get; set; }
		public int permission_id { get; set; }
		public bool is_directly { get; set; }
		public int? role_id { get; set; }
		public int permissionPriority { get; set; }
		[Display(AutoGenerateField = false)]
		public int created_by { get; set; }
		[Display(AutoGenerateField = false)]
		public DateTime created_in { get; set; }


		[ForeignKey("user_id")]
		public User User { get; set; }
		public Permission Permission { get; set; }
		[ForeignKey("role_id")]
		public Role Role { get; set; }
	}
}
