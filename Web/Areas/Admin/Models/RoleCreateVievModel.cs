using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.Models
{
    public class RoleCreateVievModel
    {
        [Required(ErrorMessage = "Role ismi boş bırakılamaz")]
        [Display(Name = "Rol adı :")]
        public string? Name { get; set; }
    }
}
