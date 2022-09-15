using Library.Domain.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("mainCompaniesTb")]
    public class Company
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = Constants.ErrorMessageRequired), MaxLength(30), MinLength(3)
            , Display(Name ="الشركة")]
        public string nameAr { get; set; }
        [MaxLength(30)]
        [Display(Name = "الاسم En")]
        public string nameEn { get; set; }
        [MaxLength(100)]
        //[Display(AutoGenerateField = false)]
        [Display(Name = "عنوان الشركة")]
        public string address { get; set; }
        [MaxLength(250)]
        [Display(Name = "وصف الشركة")]
        public string description { get; set; }
        [EmailAddress, MaxLength(100)]
        [Display(Name = "الإيميل")]
        public string email { get; set; }

        public ICollection<ProviderCompany> ProvidersCompanies { get; set; }
    }
}
