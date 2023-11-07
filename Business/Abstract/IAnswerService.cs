using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnswerService 
    {
        List<Answer> GetAll();
        Answer GetById(int id);
        void Add(Answer answer);
    }
}
