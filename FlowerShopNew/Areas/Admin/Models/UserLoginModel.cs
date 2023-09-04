using System.ComponentModel.DataAnnotations;

namespace FlowerShopNew.Areas.Admin.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Lütfen emaili boş geçmeyiniz...")]
        [EmailAddress(ErrorMessage = "Lütfen email formatında bir değer belirtiniz...")]
        public string Email{ get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz.")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen uygun formatta şifre giriniz.")]
        public string Password { get; set; }


        [Display(Name = "Beni Hatırla")]
        public bool Persistent { get; set; }
        public bool Lock { get; set; }

    }
       
}
