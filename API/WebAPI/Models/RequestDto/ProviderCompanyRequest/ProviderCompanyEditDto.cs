using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.RequestDto.ProviderCompanyRequest
{
    public class ProviderCompanyEditDto
    {		
		public string codeNo { get; set; }
		[Required]
		public string host { get; set; }
		[Required]
		[RegularExpression(@"^[1-9]{1}[0-9]{1,5}$", ErrorMessage = "Characters are not allowed.")]
		public string port { get; set; }
		[Required]
		public string linkSuffix { get; set; }
		public bool is_active { get; set; } = true;
		internal ProviderCompany toModel(ProviderCompany mdl,ProviderCompanyEditDto dto)
		{
			mdl.codeNo = dto.codeNo;
			mdl.host = dto.host;
			mdl.port = dto.port;
			mdl.linkSuffix = dto.linkSuffix;
			mdl.is_active = dto.is_active;
			return mdl;
		}
		
	}
}
