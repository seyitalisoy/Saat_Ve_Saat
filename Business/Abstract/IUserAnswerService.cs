using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserAnswerService
    {
        List<UserAnswer> GetAll();

        UserAnswer GetById(int id);

        void Add(UserAnswer userAnswer);
        void Update(UserAnswer userAnswer);
    }
}
