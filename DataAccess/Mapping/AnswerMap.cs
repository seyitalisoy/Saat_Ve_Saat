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
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(a => a.AnswerId);
            builder.Property(a=> a.AnswerText)
                .HasMaxLength(50);

            builder.HasData(
                new Answer { AnswerId=1,QuestionId=1,AnswerText="Beğendim"},
                new Answer { AnswerId=2,QuestionId=1,AnswerText="Beğenmedim"},
                new Answer { AnswerId=3,QuestionId=2,AnswerText="İstanbul"},
                new Answer { AnswerId=4,QuestionId=2,AnswerText="Ankara"},
                new Answer { AnswerId=5,QuestionId=2,AnswerText="İzmir"},
                new Answer { AnswerId=6,QuestionId=2,AnswerText="Trabzon"}
                );
        }
    }
}
