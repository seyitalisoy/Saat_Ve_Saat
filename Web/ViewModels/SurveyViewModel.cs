using Entities.Concrete;

namespace Web.ViewModels
{
    public class SurveyViewModel
    {
        public string UserId { get; set; } = null!;
        public string? Question { get; set; }
        public List<string>? Answers { get; set; }

    }
}
