using Library.Domain.Entities;
using Library.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.RequestDto.ProviderRequest
{
    public class ProviderAddDto
    {
		[Required(ErrorMessage = Constants.ErrorMessageRequired), MaxLength(50), MinLength(4)]
		public string fullName { get; set; }
		[MaxLength(500), MinLength(20)]
		public string description { get; set; }
		public string address { get; set; }
		[Phone]
		public string mobileNum { get; set; }
		[Phone]
		public string phoneNum { get; set; }
		[Url, MaxLength(250)]
		public string accessServiceLink { get; set; }
		public string userName { get; set; }
		public string password { get; set; }
		public string accountNumber { get; set; }
		public decimal? theBalance { get; set; }
		public DateTime? subscription_date { get; set; }

		internal Provider toModel(ProviderAddDto dto)
		{
			return new Provider()
			{
				fullName = dto.fullName,
				description = dto.description,
				address = dto.address,
				mobileNum = dto.mobileNum,
				phoneNum = dto.phoneNum,
				accessServiceLink = dto.accessServiceLink,
				userName = dto.userName,
				password = dto.password,
				accountNumber = dto.accountNumber,
				theBalance = dto.theBalance,
				subscription_date = dto.subscription_date,
				is_active = true,
				created_by=1,
				created_in=DateTime.Now
			};
		}
	}
}
