using Library.Domain.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
	[Table("userTb")]
	public class User
    {
		[Key]
		public int id { get; set; }
		[Required(ErrorMessage = Constants.ErrorMessageRequired)
			, Display(Name = "نوع المستخدم")]
		public int userType_id { get; set; }
		[Required(ErrorMessage = Constants.ErrorMessageRequired), MaxLength(30)
			, Display(Name = "اسم المستخدم")]
		public string userName { get; set; }
		[Required(ErrorMessage = Constants.ErrorMessageRequired), MaxLength(50)
			, Display(Name = "كلمة المرور")]
		public string password { get; set; }
		[Display(AutoGenerateField =false)]
		public DateTime dateLastLogin { get; set; }
		[Required(ErrorMessage = Constants.ErrorMessageRequired), MaxLength(50)
			, Display(Name = "الاسم الكامل")]
		public string fullName { get; set; }
		[Required(ErrorMessage = Constants.ErrorMessageRequired), MaxLength(15)
			, Display(Name = "رقم الموبايل"),Phone]
		public string mobileNum { get; set; }
		[Display(AutoGenerateField = false)]
		public bool mustChangePassword { get; set; }
		[Display(AutoGenerateField = false)]
		public int created_by { get; set; }
		[Display(AutoGenerateField = false)]
		public DateTime created_in { get; set; }
		[Display(AutoGenerateField = false)]
		public bool is_delete { get; set; }
		[Display(AutoGenerateField = false)]
		public bool is_active { get; set; }

		[ForeignKey("userType_id")]
		public UserType UserType { get; set; }
		public CustomerAccounts Account { get; set; }
		public ICollection<UserPermissions> PermissionUsers { get; set; }
	}
}
