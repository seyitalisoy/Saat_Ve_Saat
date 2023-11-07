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
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.QuestionId);
            builder.Property(q => q.QuestionText)
                .HasMaxLength(50);
            builder.HasData(
                new Question { QuestionId=1,QuestionText="Bugünkü yemekleri beğendiniz mi?"},
                new Question { QuestionId=2,QuestionText="Düzenleyeceğimiz gezide nereye gitmek istersiniz?"}
                );
        }
    }
}
