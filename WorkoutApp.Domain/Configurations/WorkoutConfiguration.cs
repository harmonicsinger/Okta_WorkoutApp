using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkoutApp.Domain
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            // Mapping to Table
            builder.ToTable("Workout");

            // Mapping Primary Key
            builder.HasKey(x => x.WorkoutID);

            // Mapping Properties
            builder.Property(x => x.WorkoutID).IsRequired().HasColumnName("WorkoutID").UseIdentityColumn();
            builder.Property(x => x.Date).IsRequired().HasColumnName("Date").HasColumnType("datetime2");
            builder.Property(x => x.DistanceInMeters).IsRequired();
            builder.Property(x => x.TimeInSeconds).IsRequired();

        }
    }
}