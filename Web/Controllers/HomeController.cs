using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Extensions;
using Web.Models;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IAnnouncementService _service;
        private readonly IUserAnswerService _userAnswerService;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService, IQuestionService questionService, IAnswerService answerService, IAnnouncementService service, IUserAnswerService userAnswerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _questionService = questionService;
            _answerService = answerService;
            _service = service;
            _userAnswerService = userAnswerService;
        }

        public IActionResult Index()
        {
            var model = _service.GetAll();
            return View(model);
        }

        public async Task<IActionResult> Survey()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var questions = _questionService.GetAll();
            var question = questions.OrderByDescending(x => x.QuestionId).FirstOrDefault();

            var answers = _answerService.GetAll();
            var questionAnswers = answers.Where(x => x.QuestionId.Equals(question?.QuestionId)).ToList();

            var userAnswers = _userAnswerService.GetAll();
            var currentUserAnswers = userAnswers.Where(x=>x.UserId==currentUser!.Id);
            var selectedAnswer = questionAnswers.FirstOrDefault(x => x.AnswerId == currentUserAnswers?.FirstOrDefault()?.AnswerId);
            if (selectedAnswer!=null)
            {
                ViewBag.LastAnswer = selectedAnswer.AnswerText;
            }
            
            
            var model = new SurveyViewModel() 
            { 
                Question = question.QuestionText ,
                Answers= questionAnswers.Select(x=>x.AnswerText).ToList(),
                UserId = currentUser!.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Survey(string userId, string selectedAnswer)
        {
            var currentUser = await _userManager.FindByIdAsync(userId);

            var questions = _questionService.GetAll();
            var question = questions.OrderByDescending(x => x.QuestionId).FirstOrDefault();
            if (question==null || questions==null)
            {
                throw new Exception("Soru bulunamadı");
            }

            var answers = _answerService.GetAll();
            var questionAnswers = answers.Where(x => x.QuestionId.Equals(question?.QuestionId)).ToList();
            if (answers == null || questionAnswers == null)
            {
                throw new Exception("Cevaplar bulunamadı");
            }

            var userAnswers = _userAnswerService.GetAll();
            var currentUserAnswers = userAnswers.Where(x => x.UserId == currentUser!.Id);

            var answerForSelected = answers.FirstOrDefault(x=>x.AnswerText.Equals(selectedAnswer));
            if (answerForSelected==null)
            {
                return RedirectToAction(nameof(Survey));
            }
            var answerIdForSelected = answerForSelected.AnswerId;

            var oldUserAnswer = currentUserAnswers.FirstOrDefault(userAnswer => questionAnswers.Any(qAnswer => userAnswer.AnswerId == qAnswer.AnswerId));
            if (oldUserAnswer==null)
            {
                 _userAnswerService.Add(new UserAnswer() { UserId = currentUser.Id,AnswerId= answerIdForSelected});
            }
            else
            {
                var userAnswer = answers.FirstOrDefault(x => x.AnswerText == selectedAnswer);
                var result = _userAnswerService.GetById(oldUserAnswer.UserAnswerId);
                result.AnswerId = userAnswer.AnswerId;
                _userAnswerService.Update(result);
            }
            
            return RedirectToAction(nameof(Survey));
        }



        

    }
}