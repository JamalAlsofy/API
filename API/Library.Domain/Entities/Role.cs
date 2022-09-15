using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
	[Table("roleTb")]
	public class Role
    {
		[Key]
		public int id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public bool is_fixed { get; set; }
		[Display(AutoGenerateField = false)]
		public int created_by { get; set; }
		[Display(AutoGenerateField = false)]
		public DateTime created_in { get; set; }

		public ICollection<UserTypeRole> UserTypeRoles { get; set; }
		public ICollection<PermissionRole> PermissionRoles { get; set; }
	}
}
