using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Position : IEntity
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; } 
        //collection navigation property
    }
}
