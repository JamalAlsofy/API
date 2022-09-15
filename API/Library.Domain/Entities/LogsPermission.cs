using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
	[Table("logsPermissionTb")]
	public class LogsPermission
    {
		[Key]
		public long id { get; set; }
		public DateTime theDate { get; set; }
		public int user_id { get; set; }
		[ForeignKey("Permission")]
		public int permission_id { get; set; }
		public bool permissionStatus { get; set; }
		public int created_by { get; set; }
		public DateTime created_in { get; set; }

		[ForeignKey("user_id")]
		public User User { get; set; }
		//[ForeignKey("permission_id")]
		public Permission Permission { get; set; }
	}
}
