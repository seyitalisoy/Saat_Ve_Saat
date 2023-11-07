using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserAnswerManager : IUserAnswerService
    {
        IUserAnswerDal _userAnswerDal;

        public UserAnswerManager(IUserAnswerDal userAnswerDal)
        {
            _userAnswerDal = userAnswerDal;
        }

        public void Add(UserAnswer userAnswer)
        {
            _userAnswerDal.Add(userAnswer);
        }

        public List<UserAnswer> GetAll()
        {
            return _userAnswerDal.GetAll();
        }

        public UserAnswer GetById(int id)
        {
            return _userAnswerDal.Get(p => p.UserAnswerId.Equals(id));
        }

        public void Update(UserAnswer userAnswer)
        {
            _userAnswerDal.Update(userAnswer);
        }
    }
}
