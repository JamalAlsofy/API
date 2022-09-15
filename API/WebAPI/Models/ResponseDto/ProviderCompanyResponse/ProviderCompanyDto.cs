using Library.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Models.ResponseDto.ProviderCompanyResponse
{
    public class ProviderCompanyDto
    {
		public int id { get; set; }
		public int mainCom_id { get; set; }
		public int provider_id { get; set; }
		public string codeNo { get; set; }
		public string host { get; set; }
		public string port { get; set; }
		public string linkSuffix { get; set; }
		public bool is_active { get; set; }

        internal ProviderCompanyDto fromModel(ProviderCompany dto)
        {
            if (dto == null) return null;
            return new ProviderCompanyDto()
            {
                id = dto.id,
                mainCom_id = dto.mainCom_id,
                provider_id = dto.provider_id,
                codeNo = dto.codeNo,
                host = dto.host,
                port = dto.port,
                linkSuffix = dto.linkSuffix,
                is_active = dto.is_active
            };
        }
        internal List<ProviderCompanyDto> fromModel(List<ProviderCompany> dto)
        {
            var lst = new List<ProviderCompanyDto>();
            lst.AddRange(dto.Select((x) => fromModel(x)));
            return lst;
        }
    }
}
