using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; } 
        public int PositionId { get; set; } //foreign key
        public Position? Position { get; set; }
        public int DepartmentId { get; set; }  //foreign key
        public Department? Department { get; set; }

        //user inherit employee (email,password)     
        public string TcNo { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        //password ileride eklenecek
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime? DateOfHire { get; set; }
        public DateTime? BirthDay { get; set; }


    }
}
