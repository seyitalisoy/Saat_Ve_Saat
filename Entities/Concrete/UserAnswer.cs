using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserAnswer : IEntity
    {
        public int UserAnswerId { get; set; }
        public int AnswerId { get; set; }
        public string? UserId { get; set; }
    }
}
