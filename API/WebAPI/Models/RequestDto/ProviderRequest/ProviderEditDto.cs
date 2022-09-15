using Library.Domain.Entities;
using Library.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.RequestDto.ProviderRequest
{
    public class ProviderEditDto
    {
		//[Required(ErrorMessage = Constants.ErrorMessageRequired)]
		//public int id { get; set; }
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
		internal Provider toModel(Provider mdl,ProviderEditDto dto)
		{
			mdl.fullName = dto.fullName;
			mdl.description = dto.description;
			mdl.address = dto.address;
			mdl.mobileNum = dto.mobileNum;
			mdl.phoneNum = dto.phoneNum;
			mdl.accessServiceLink = dto.accessServiceLink;
			mdl.userName = dto.userName;
			mdl.password = dto.password;
			mdl.accountNumber = dto.accountNumber;
			mdl.theBalance = dto.theBalance;
			mdl.subscription_date = dto.subscription_date;			
			return mdl;
		}

	}
}
