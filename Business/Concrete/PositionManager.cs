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
    public class PositionManager : IPositionService
    {
        IPositionDal _positionDal;

        public PositionManager(IPositionDal positionDal)
        {
            _positionDal = positionDal;
        }

        public void Add(Position position)
        {
            _positionDal.Add(position);
        }

        public List<Position> GetAll()
        {
            return _positionDal.GetAll();
        }

        public Position GetById(int id)
        {
            return _positionDal.Get(p => p.PositionId.Equals(id));
        }
    }
}
