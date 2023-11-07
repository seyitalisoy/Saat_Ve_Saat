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
    public class DepartmentManager : IDepartmenService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public void Add(Department department)
        {
            _departmentDal.Add(department);
        }

        public List<Department> GetAll()
        {
            return _departmentDal.GetAll();
        }

        public Department GetById(int id)
        {
                return _departmentDal.Get(p => p.DepartmentId.Equals(id));
        }
    }
}
