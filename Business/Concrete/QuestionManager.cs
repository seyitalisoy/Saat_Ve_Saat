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
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public void Add(Question question)
        {
            _questionDal.Add(question);
        }

        public List<Question> GetAll()
        {
            return _questionDal.GetAll();
        }

        public Question GetById(int id)
        {
            return _questionDal.Get(q=>q.QuestionId == id);
        }

    }
}
