using System.ComponentModel.DataAnnotations;
using Library.Domain.Utils;
using Library.Domain.Entities;

namespace WebAPI.Models.RequestDto.CompanyRequest
{
    public class CompanyAddDto
    {
        [Required(ErrorMessage = Constants.ErrorMessageRequired), MaxLength(30), MinLength(3)]
        public string nameAr { get; set; }
        [MaxLength(30)]
        public string nameEn { get; set; }
        [MaxLength(100)]
        public string address { get; set; }
        [MaxLength(250)]
        public string description { get; set; }
        [EmailAddress, MaxLength(100)]
        public string email { get; set; }
        internal Company toModel(CompanyAddDto dto)
        {
            return new Company()
            {
                nameAr = dto.nameAr,
                nameEn = dto.nameEn,
                description = dto.description,
                address = dto.address,
                email = dto.email
            };
        }
    }
}
