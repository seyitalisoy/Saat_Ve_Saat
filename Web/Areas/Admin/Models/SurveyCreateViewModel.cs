using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.Models
{
    public class SurveyCreateViewModel
    {
        [Required(ErrorMessage = "Soru alanı boş bırakılamaz")]
        public string? QuestionText { get; set; }

        [Required(ErrorMessage = "Cevap alanı boş bırakılamaz")]
        public List<string>? AnswersText { get; set; }
    }
}
