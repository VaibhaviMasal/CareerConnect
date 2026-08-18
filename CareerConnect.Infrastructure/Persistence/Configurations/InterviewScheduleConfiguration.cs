using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CareerConnect.Domain.Entities;

namespace CareerConnect.Infrastructure.Persistence.Configurations;

public class InterviewScheduleConfiguration : IEntityTypeConfiguration<InterviewSchedule>
{
    public void Configure(EntityTypeBuilder<InterviewSchedule> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        builder.HasOne(e => e.Application)
               .WithMany(a => a.InterviewSchedules)
               .HasForeignKey(e => e.ApplicationId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}