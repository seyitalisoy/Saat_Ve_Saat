using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Answer : IEntity
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; } //foreign key
        public Question? Question { get; set; }
        public string? AnswerText { get; set; }
    }
}
