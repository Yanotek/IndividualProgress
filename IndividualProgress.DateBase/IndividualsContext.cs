using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IndividualProgress.DateBase
{
    public partial class IndividualsContext : DbContext
    {
        public virtual DbSet<Direction> Direction { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<Sphere> Sphere { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-A0J4PO5T\\SQLEXPRESS;Database=Individuals;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direction>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.HasOne(d => d.Sphere)
                    .WithMany(p => p.Direction)
                    .HasForeignKey(d => d.SphereId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Direction_Sphere");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.DirectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Direction");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_Event_Level");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Event_Location");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Adress).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<Part>(entity =>
            {

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Part_Event");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Part_Student");
            });

            modelBuilder.Entity<Sphere>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Student_Group");
            });
        }
    }
}
