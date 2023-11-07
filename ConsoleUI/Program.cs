// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

//Console.WriteLine("Hello, World!");

EmployeeManager employeeManager = new EmployeeManager(new EmployeeDal());
//QuestionManager questionManager = new QuestionManager(new QuestionDal());
//TestBirthDay(employeeManager);
//TestEmployeesBirthDay(employeeManager);

//DepartmentManager departmentManager = new DepartmentManager(new DepartmentDal());
//departmentManager.Add(new Department { DepartmentName = "Arşiv" });
//var departments = departmentManager.GetAll();
//foreach (var deparment in departments)
//{
//    Console.WriteLine(deparment.DepartmentName);
//}

PositionManager positionManager = new PositionManager(new PositionDal());
positionManager.Add(new Position { PositionName = "Uzman yardımcısı" });
var departments = positionManager.GetAll();
foreach (var deparment in departments)
{
    Console.WriteLine(deparment.PositionName);
}





static void TestEmployeesBirthDay(EmployeeManager employeeManager)
{
    foreach (var employee in employeeManager.GetAll())
    {
        Console.Write(employee.FirstName + " " + employee.LastName);

        if (employee.BirthDay.HasValue && employee.DateOfHire.HasValue)
        {
            Console.Write(" " + employee.DateOfHire.Value.ToString("dd.MM.yyyy") + " " + employee.BirthDay.Value.ToString("dd.MM.yyyy"));
        }

        Console.WriteLine();
    }
}


static void TestBirthDay(EmployeeManager employeeManager)
{
    foreach (var item in employeeManager.GetAllByBirthDayForThisWeek())
    {
        if (item.BirthDay.HasValue)
        {
            Console.WriteLine(item.FirstName + " " + item.BirthDay.Value.ToString("dd.MM.yyyy"));
        }

    }
}

