using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.Models
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Kullanıcı Adı :")]
        public string? UserName { get; set; }

        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        [Display(Name = "Email :")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz.")]
        [Display(Name = "Telefon :")]
        public string Phone { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Şifre :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifre aynı değildir.")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz")]
        [Display(Name = "Şifre Tekrar :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir")]
        public string PasswordConfirm { get; set; } = null!;

        public int PositionId { get; set; }
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Tc No boş bırakılamaz")]
        public string TcNo { get; set; } = null!;

        [Required(ErrorMessage = "Ad boş bırakılamaz")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Soyad boş bırakılamaz")]
        public string LastName { get; set; } = null!;
        public DateTime? DateOfHire { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
