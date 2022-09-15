using Library.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Models.ResponseDto.CompanyResponse
{
    public class CompanyResponseDto
    {
        public int id { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string email { get; set; }


        internal CompanyResponseDto fromModel(Company dto)
        {
            if (dto == null) return null;
            return new CompanyResponseDto()
            {
                id = dto.id,
                nameAr=dto.nameAr,
                nameEn=dto.nameEn,
                description=dto.description,
                address=dto.address,
                email=dto.email
            };
        }
        internal List<CompanyResponseDto> fromModel(List<Company> dto)
        {
            var lst = new List<CompanyResponseDto>();
                lst.AddRange(dto.Select((x)=> fromModel(x)));
            return lst;         
        }

    }
}
