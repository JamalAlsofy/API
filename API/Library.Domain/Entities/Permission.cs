using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
	[Table("permissionTb")]
	public class Permission
    {
		[Key]
		public int id { get; set; }
		public string permissionCode { get; set; }
		public int userType_id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public bool is_main { get; set; }
		public int parent_id { get; set; }

		[ForeignKey("parent_id")]
		public ICollection<Permission> Permissions { get; set; }

		public ICollection<PermissionRole> PermissionRoles { get; set; }

        [ForeignKey("permission_id")]
        public ICollection<UserPermissions> PermissionUsers { get; set; }
    }
}
