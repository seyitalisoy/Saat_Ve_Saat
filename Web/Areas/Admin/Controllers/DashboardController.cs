using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web.Areas.Admin.Models;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserAnswerService _userAnswerService;

        public DashboardController(IQuestionService questionService, IAnswerService answerService, UserManager<AppUser> userManager, IUserAnswerService userAnswerService)
        {
            _questionService = questionService;
            _answerService = answerService;
            _userManager = userManager;
            _userAnswerService = userAnswerService;
        }

        public async Task<IActionResult> Index()
        {
            var questions = _questionService.GetAll();
            var question = questions.OrderByDescending(x => x.QuestionId).FirstOrDefault(); // soru

            var answers = _answerService.GetAll();
            var questionAnswers = answers.Where(x => x.QuestionId.Equals(question?.QuestionId)).ToList(); // cevap listesi

            var userAnswers = _userAnswerService.GetAll();

            var users = _userManager.Users.ToList();      

            return View(new SurveyTableViewModel()
            {
                Answers = questionAnswers,
                QuestionText = question.QuestionText,
                Users = users,
                UserAnswers = userAnswers,
            });
        }

        public IActionResult CreateSurvey()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSurvey(SurveyCreateViewModel request)
        {
            var answerTextList = request.AnswersText; 
            var questionText = request.QuestionText;

            _questionService.Add(new Question { QuestionText=questionText});

            foreach (var answerText in answerTextList!)
            {
                var questions = _questionService.GetAll();
                var lastQuestion = questions.OrderByDescending(x => x.QuestionId).FirstOrDefault();
                _answerService.Add(new Answer() { AnswerText=answerText,QuestionId=lastQuestion!.QuestionId});
            }

            return RedirectToAction(nameof(CreateSurvey));
        }
    }
}
