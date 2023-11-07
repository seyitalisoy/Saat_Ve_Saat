using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);
            builder.Property(e => e.FirstName)
                .HasMaxLength(50);


            builder.HasData(
                new Employee { EmployeeId = 1, FirstName = "Ahmet", LastName = "Yılmaz", DepartmentId = 1, PositionId = 1, PhoneNumber = "5303232131", TcNo = "12345678912", DateOfHire = new DateTime(2013, 10, 10), BirthDay = new DateTime(1995, 10, 18) },
                new Employee { EmployeeId = 2, FirstName = "Mehmet", LastName = "Hakan", DepartmentId = 1, PositionId = 2, PhoneNumber = "5303232141", TcNo = "22245678912", DateOfHire = new DateTime(2015, 8, 9), BirthDay = new DateTime(1998, 6, 23) },
                new Employee { EmployeeId = 3, FirstName = "Cevdet", LastName = "DeliGül", DepartmentId = 2, PositionId = 1, PhoneNumber = "5303232145", TcNo = "22245678455", DateOfHire = new DateTime(2020, 3, 4), BirthDay = new DateTime(1989, 8, 20) },
                new Employee { EmployeeId = 4, FirstName = "Haldun", LastName = "Kara", DepartmentId = 2, PositionId = 2, PhoneNumber = "5373232174", TcNo = "22245678488", DateOfHire = new DateTime(2022, 5, 8), BirthDay = new DateTime(1991, 9, 2) },
                new Employee { EmployeeId = 5, FirstName = "Zeynep", LastName = "Arkadaş", DepartmentId = 1, PositionId = 2, PhoneNumber = "5553232193", TcNo = "22245678404", DateOfHire = new DateTime(2022, 7, 1), BirthDay = new DateTime(1989, 9, 5) }
                );
        }
    }
}
