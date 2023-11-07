using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDepartmenService
    {
        List<Department> GetAll();

        Department GetById(int id);
        void Add(Department department);
    }
}
