using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "Role ismi boş bırakılamaz")]
        [Display(Name = "Role adı :")]
        public string Name { get; set; } = null!;
    }
}
