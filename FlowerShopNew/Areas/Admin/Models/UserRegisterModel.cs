using System.ComponentModel.DataAnnotations;

namespace FlowerShopNew.Areas.Admin.Models
{
    public class UserRegisterModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Lütfen İsminizi Boş Geçmeyiniz...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Boş Geçmeyiniz...")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen emaili boş geçmeyiniz...")] 
        [EmailAddress(ErrorMessage = "Lütfen email formatında bir değer belirtiniz...")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz...")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }


    }
}
