using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public void Add(Employee employee)
        {
            var result = BusinessRules.Run(CheckIfEmployeePhoneNumberExists(employee),
                CheckIfEmployeeTcNoExists(employee));
            if (result)
            {
                _employeeDal.Add(employee);
            }

        }

        public void Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
        }

        public Employee GetById(int employeeId)
        {
            return _employeeDal.Get(p => p.EmployeeId.Equals(employeeId));
        }

        public List<Employee> GetAll()
        {
            return _employeeDal.GetAll();
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public void Update(Employee employee)
        {

            _employeeDal.Update(employee);

        }

        public bool CheckIfEmployeeTcNoExists(Employee employee)
        {
            var result = _employeeDal.GetAll(e => e.TcNo == employee.TcNo).Any();
            if (result)
            {
                throw new Exception(Messages.TcNoExists);
            }
            return true;
        }

        public bool CheckIfEmployeePhoneNumberExists(Employee employee)
        {

            var result = _employeeDal.GetAll(e => e.PhoneNumber == employee.PhoneNumber).Any();
            if (result)
            {
                throw new Exception(Messages.PhoneNumberExists);
            }
            return true;
        }

        public List<Employee> GetAllByBirthDayForThisWeek()
        {
            List<Employee> result = new List<Employee>();
            foreach (var emp in _employeeDal.GetAll())
            {
                DateTime today = DateTime.Now;
                if (emp.BirthDay.HasValue)
                {
                    DateTime tempEmp = new DateTime(today.Year, emp.BirthDay.Value.Month, emp.BirthDay.Value.Day);
                    TimeSpan span = tempEmp - today;
                    if (span.Days >= 0 && span.Days < 7)
                    {
                        result.Add(emp);
                    }
                }
            }
            return result;
        }

        public List<Employee> GetLastestEmployees()
        {
            return _employeeDal.GetAll().
                OrderByDescending(e=>e.EmployeeId)
                .Take(3)
                .ToList();
                
        }
    }
}
