using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.RequestDto.ProviderCompanyRequest
{
    public class ProviderCompanyAddDto
    {
		[Required]
		public int mainCom_id { get; set; }
		[Required]
		public int provider_id { get; set; }
		public string codeNo { get; set; }
		[Required]
		public string host { get; set; }
		[Required]
		[RegularExpression(@"^[1-9]{1}[0-9]{1,5}$", ErrorMessage = "Characters are not allowed.")]
		public string port { get; set; }
		[Required]
		public string linkSuffix { get; set; }
		internal ProviderCompany toModel(ProviderCompanyAddDto dto)
		{
			return new ProviderCompany()
			{
				mainCom_id = dto.mainCom_id,
				provider_id = dto.provider_id,
				codeNo = dto.codeNo,
				host = dto.host,
				port = dto.port,
				linkSuffix = dto.linkSuffix,
				is_active = true
			};
		}
	}
}
