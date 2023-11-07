using Microsoft.AspNetCore.Identity;

namespace Web.Localizations
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new() { Code = "DuplicateUserName", Description =$"{userName} kullanıcı adı alınmıştır."};
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = "DuplicateEmail", Description = $"{email} email adresi kullanılmıştır." };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = "PasswordToShort", Description = "Şifre en az 6 karakterli olmalıdır." };
        }
    }
}
