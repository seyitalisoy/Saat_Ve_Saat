using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPositionService
    {
        List<Position> GetAll();
        
        Position GetById(int id);
        void Add(Position position);
    }
}
