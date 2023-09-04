using Microsoft.AspNetCore.Identity;

namespace FlowerShopNew.CustomValidations
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName) => new IdentityError { Code = "DuplicateUserName", Description = $"\"{userName}\" kullanıcı adı kullanılmaktadır." };
        public override IdentityError InvalidUserName(string userName) => new IdentityError { Code = "InvalidUserName", Description = "Geçersiz kullanıcı adı." };
        public override IdentityError DuplicateEmail(string email) => new IdentityError { Code = "DuplicateEmail", Description = $"\"{email}\" başka bir kullanıcı tarafından kullanılmaktadır." };
        public override IdentityError InvalidEmail(string email) => new IdentityError { Code = "InvalidEmail", Description = "Geçersiz email." };
    }



    //public class TrIdentityErrorDescriber : IdentityErrorDescriber
    //{
    //    public override IdentityError DuplicateEmail(string email)
    //    {
    //        return new IdentityError { Code = "DuplicateEmail", Description = $"'{email}'mail adresi kullanılmaktadır. Başka bir adres girin." };
    //    }

    //    public override IdentityError LoginAlreadyAssociated()
    //    {
    //        return new IdentityError { Code = "LoginAlreadyAssociated", Description = "Bu kullanıcı oturumu zaten açık." };
    //    }

    //    public override IdentityError InvalidEmail(string email)
    //    {
    //        return new IdentityError { Code = "InvalidEmail", Description = "Geçersiz mail adresi." }; ;
    //    }
    //}
}
