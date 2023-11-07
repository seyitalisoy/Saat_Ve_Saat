using Core.Entities;
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
    public class AnnouncementMap : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(b => b.AnnouncementId);

            builder.Property(b => b.Title)
                .HasMaxLength(int.MaxValue);

            builder.Property(b => b.Content)
                .HasMaxLength(int.MaxValue);

            builder.Property(b => b.ImageUrl)
                .HasMaxLength(int.MaxValue);

            builder.HasData(
                new Announcement { AnnouncementId=1,
                    Title="23 Nisan",
                    Content="23 Nisan Ulusual Egemenlik ve Çocuk Bayramımız kutlu olsun.",
                    ImageUrl= "/images/1.jpg"
                },
                new Announcement
                {
                    AnnouncementId = 2,
                    Title = "Toplantılar Başlıyor",
                    Content = "Eylül ayı toplantılarımız başlıyor.",
                    ImageUrl = "/images/2.jpg"
                },
                new Announcement
                {
                    AnnouncementId = 3,
                    Title = "Saat Fuarı",
                    Content = "Geleneksel Saat fuarı İstanbul'da başlıyor.",
                    ImageUrl = "/images/3.jpg"
                }
                );
        }
    }
}
