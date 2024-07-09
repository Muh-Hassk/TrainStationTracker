using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainStationTracker.API.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<Trainstation> Trainstations { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=C##TRAINSTATIONDB;PASSWORD=Test123;DATA SOURCE=localhost:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##TRAINSTATIONDB")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("BOOKINGS");

                entity.Property(e => e.Bookingid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BOOKINGID");

                entity.Property(e => e.Bookingtime)
                    .HasPrecision(6)
                    .HasColumnName("BOOKINGTIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Paymentstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENTSTATUS");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIPID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIALS");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Content)
                    .HasColumnType("CLOB")
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Createdat)
                    .HasPrecision(6)
                    .HasColumnName("CREATEDAT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("'pending'\n   ");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TESTIMONIAL_USER");
            });

            modelBuilder.Entity<Trainstation>(entity =>
            {
                entity.HasKey(e => e.Stationid)
                    .HasName("SYS_C008477");

                entity.ToTable("TRAINSTATIONS");

                entity.Property(e => e.Stationid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STATIONID");

                entity.Property(e => e.Createdat)
                    .HasPrecision(6)
                    .HasColumnName("CREATEDAT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP\n   ");

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(9,6)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(9,6)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.Stationname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STATIONNAME");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("TRIPS");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIPID");

                entity.Property(e => e.Availableseats)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVAILABLESEATS");

                entity.Property(e => e.Createdat)
                    .HasPrecision(6)
                    .HasColumnName("CREATEDAT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Departuretime)
                    .HasPrecision(6)
                    .HasColumnName("DEPARTURETIME");

                entity.Property(e => e.Destinationstationid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DESTINATIONSTATIONID");

                entity.Property(e => e.Duratointime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATOINTIME");

                entity.Property(e => e.Originstationid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORIGINSTATIONID");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("PRICE");

                entity.HasOne(d => d.Destinationstation)
                    .WithMany(p => p.TripDestinationstations)
                    .HasForeignKey(d => d.Destinationstationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DESTINATION_STATION");

                entity.HasOne(d => d.Originstation)
                    .WithMany(p => p.TripOriginstations)
                    .HasForeignKey(d => d.Originstationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORIGIN_STATION");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasIndex(e => new { e.Username, e.Email }, "USERS_UK1")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Createdat)
                    .HasPrecision(6)
                    .HasColumnName("CREATEDAT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
