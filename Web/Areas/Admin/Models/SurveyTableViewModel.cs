using Entities.Concrete;
using Web.Models;

namespace Web.Areas.Admin.Models
{
    public class SurveyTableViewModel
    {
        public string? QuestionText { get; set; }
        public List<Answer>? Answers { get; set; }
        public List<UserAnswer>? UserAnswers { get; set; }
        public List<AppUser>? Users  { get; set; }

    }
}
