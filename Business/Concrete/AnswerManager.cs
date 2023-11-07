using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnswerManager : IAnswerService
    {
        IAnswerDal _answerDal;

        public AnswerManager(IAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }

        public void Add(Answer answer)
        {
            _answerDal.Add(answer);
        }

        public List<Answer> GetAll()
        {
            return _answerDal.GetAll();
        }

        public Answer GetById(int id)
        {
            return _answerDal.Get(a=>a.AnswerId == id);
        }
    }
}
