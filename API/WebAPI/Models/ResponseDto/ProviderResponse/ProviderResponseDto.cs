using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.ResponseDto.ProviderResponse
{
    public class ProviderResponseDto
    {
		public int id { get; set; }
		public string fullName { get; set; }
		public string description { get; set; }
		public string address { get; set; }
		public string mobileNum { get; set; }
		public string phoneNum { get; set; }
		public string accessServiceLink { get; set; }
		public string userName { get; set; }
		public string password { get; set; }
		public string accountNumber { get; set; }
		public decimal? theBalance { get; set; }
		public DateTime? subscription_date { get; set; }
		public bool is_active { get; set; }

        internal ProviderResponseDto fromModel(Provider dto)
        {
            if (dto == null) return null;
            return new ProviderResponseDto()
            {
                id = dto.id,
                fullName = dto.fullName,
                description = dto.description,
                address = dto.address,
                mobileNum = dto.mobileNum,
                phoneNum=dto.phoneNum,
                accessServiceLink = dto.accessServiceLink,
                userName = dto.userName,
                password = dto.password,
                accountNumber = dto.accountNumber,
                theBalance = dto.theBalance,
                subscription_date = dto.subscription_date,
                is_active = dto.is_active,
            };
        }
        internal List<ProviderResponseDto> fromModel(List<Provider> dto)
        {
            var lst = new List<ProviderResponseDto>();
            lst.AddRange(dto.Select((x) => fromModel(x)));
            return lst;
        }

    }
}
