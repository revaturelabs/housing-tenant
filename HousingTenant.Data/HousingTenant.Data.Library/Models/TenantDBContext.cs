using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HousingTenant.Data.Library.Models
{
    public partial class TenantDBContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Apartment> Apartment { get; set; }
        public virtual DbSet<ApartmentComplex> ApartmentComplex { get; set; }
        public virtual DbSet<ArrivalInformation> ArrivalInformation { get; set; }
        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<BatchLookup> BatchLookup { get; set; }
        public virtual DbSet<Complaint> Complaint { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Maintenance> Maintenance { get; set; }
        public virtual DbSet<MaintenanceLookup> MaintenanceLookup { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestLookup> RequestLookup { get; set; }
        public virtual DbSet<Supplies> Supplies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\projectsv13;Database=TenantDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Address");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("Apartment", "Apartment");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ApartmentComplexId).HasColumnName("ApartmentComplexID");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NumBeds).HasDefaultValueSql("6");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Apartment)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Apartment__Addre__2B3F6F97");

                entity.HasOne(d => d.ApartmentComplex)
                    .WithMany(p => p.Apartment)
                    .HasForeignKey(d => d.ApartmentComplexId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Apartment__Apart__2A4B4B5E");
            });

            modelBuilder.Entity<ApartmentComplex>(entity =>
            {
                entity.ToTable("ApartmentComplex", "Apartment");

                entity.Property(e => e.ApartmentComplexId).HasColumnName("ApartmentComplexID");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ComplexName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ApartmentComplex)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Apartment__Addre__267ABA7A");
            });

            modelBuilder.Entity<ArrivalInformation>(entity =>
            {
                entity.ToTable("ArrivalInformation", "Arrival");

                entity.Property(e => e.ArrivalInformationId).HasColumnName("ArrivalInformationID");

                entity.Property(e => e.ArrivalDate).HasColumnType("date");

                entity.Property(e => e.BatchId).HasColumnName("BatchID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.ArrivalInformation)
                    .HasForeignKey(d => d.BatchId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ArrivalIn__Batch__5165187F");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ArrivalInformation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__ArrivalIn__Perso__52593CB8");
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.ToTable("Batch", "Batch");

                entity.Property(e => e.BatchId).HasColumnName("BatchID");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.BatchLookupId).HasColumnName("BatchLookupID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.BatchLookup)
                    .WithMany(p => p.Batch)
                    .HasForeignKey(d => d.BatchLookupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Batch__BatchLook__4D94879B");
            });

            modelBuilder.Entity<BatchLookup>(entity =>
            {
                entity.ToTable("BatchLookup", "Batch");

                entity.Property(e => e.BatchLookupId).HasColumnName("BatchLookupID");

                entity.Property(e => e.BatchType)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__Complain__33A8519AAECE3844");

                entity.ToTable("Complaint", "Request");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender", "Person");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.Gender1)
                    .IsRequired()
                    .HasColumnName("Gender")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__Maintena__33A8519A5E9DB898");

                entity.ToTable("Maintenance", "Request");

                entity.Property(e => e.RequestId)
                    .HasColumnName("RequestID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.MaintenanceTypeId).HasColumnName("MaintenanceTypeID");

                entity.HasOne(d => d.MaintenanceType)
                    .WithMany(p => p.Maintenance)
                    .HasForeignKey(d => d.MaintenanceTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Maintenan__Maint__44FF419A");

                entity.HasOne(d => d.Request)
                    .WithOne(p => p.Maintenance)
                    .HasForeignKey<Maintenance>(d => d.RequestId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Maintenan__Reque__440B1D61");
            });

            modelBuilder.Entity<MaintenanceLookup>(entity =>
            {
                entity.HasKey(e => e.MaintenanceTypeId)
                    .HasName("PK__Maintena__C1017E6B107D4C54");

                entity.ToTable("MaintenanceLookup", "Request");

                entity.Property(e => e.MaintenanceTypeId).HasColumnName("MaintenanceTypeID");

                entity.Property(e => e.MaintenanceType)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Person");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.HomeAddressId).HasColumnName("HomeAddressID");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.ApartmentId)
                    .HasConstraintName("FK__Person__Apartmen__31EC6D26");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Person__GenderID__33D4B598");

                entity.HasOne(d => d.HomeAddress)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.HomeAddressId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Person__HomeAddr__32E0915F");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request", "Request");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.RequestLookupId).HasColumnName("RequestLookupID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Request__PersonI__3A81B327");

                entity.HasOne(d => d.RequestLookup)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.RequestLookupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Request__Request__398D8EEE");
            });

            modelBuilder.Entity<RequestLookup>(entity =>
            {
                entity.ToTable("RequestLookup", "Request");

                entity.Property(e => e.RequestLookupId).HasColumnName("RequestLookupID");

                entity.Property(e => e.RequestType)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Supplies>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__Supplies__33A8519ADAB3146A");

                entity.ToTable("Supplies", "Request");

                entity.Property(e => e.RequestId)
                    .HasColumnName("RequestID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.HasOne(d => d.Request)
                    .WithOne(p => p.Supplies)
                    .HasForeignKey<Supplies>(d => d.RequestId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Supplies__Reques__3E52440B");
            });
        }
    }
}