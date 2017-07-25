using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace HousingTenant.Data.Library.AzModels
{
    public partial class HousingTenantDBContext : DbContext
    {
        private IConfigurationRoot _config;

        public HousingTenantDBContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Apartment> Apartment { get; set; }
        public virtual DbSet<ApartmentComplex> ApartmentComplex { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestType> RequestType { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<SupplyRequest> SupplyRequest { get; set; }
        public virtual DbSet<SupplyType> SupplyType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:HousingTenantConnectionAzure"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Tenant");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Address2).HasMaxLength(150);

                entity.Property(e => e.Addressguid).HasDefaultValueSql("newid()");

                entity.Property(e => e.ApartmentNumber).HasMaxLength(10);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("Apartment", "Tenant");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Apartmentguid).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Apartment)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tenant_Apartment_AddressId");

                entity.HasOne(d => d.ApartmentComplex)
                    .WithMany(p => p.Apartment)
                    .HasForeignKey(d => d.ApartmentComplexId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tenant_Apartment_ApartmentComplexId");
            });

            modelBuilder.Entity<ApartmentComplex>(entity =>
            {
                entity.ToTable("ApartmentComplex", "Tenant");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.ApartmentComplexguid).HasDefaultValueSql("newid()");

                entity.Property(e => e.ComplexName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsWalkingDistance)
                    .HasColumnName("isWalkingDistance")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ApartmentComplex)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tenant_ApartmentComplex_AddressId");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender", "Tenant");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Gender1)
                    .HasColumnName("Gender")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Tenant");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.ArrivalDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HasCar).HasDefaultValueSql("0");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Personguid).HasDefaultValueSql("newid()");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Tenant_Person_AddressId");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tenant_Person_GenderId");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request", "Request");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.IsUrgent)
                    .HasColumnName("isUrgent")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Requestguid).HasDefaultValueSql("newid()");

                entity.Property(e => e.StatusId).HasDefaultValueSql("1");

                entity.HasOne(d => d.InitiatorNavigation)
                    .WithMany(p => p.RequestInitiatorNavigation)
                    .HasForeignKey(d => d.Initiator)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Request_Request_Initiator");

                entity.HasOne(d => d.PersonIdAccusedNavigation)
                    .WithMany(p => p.RequestPersonIdAccusedNavigation)
                    .HasForeignKey(d => d.PersonIdAccused)
                    .HasConstraintName("FK_Request_Request_PersonIdAccusedId");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.RequestTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Request_Request_RequestTypeId");
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.ToTable("RequestType", "Request");

                entity.Property(e => e.RequestType1)
                    .IsRequired()
                    .HasColumnName("RequestType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status", "Request");

                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Status1)
                    .IsRequired()
                    .HasColumnName("Status")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SupplyRequest>(entity =>
            {
                entity.ToTable("SupplyRequest", "Request");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.SupplyRequest)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Request_SupplyRequest_RequestId");

                entity.HasOne(d => d.SupplyType)
                    .WithMany(p => p.SupplyRequest)
                    .HasForeignKey(d => d.SupplyTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Request_SupplyRequest_SuppyTypeId");
            });

            modelBuilder.Entity<SupplyType>(entity =>
            {
                entity.ToTable("SupplyType", "Request");

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Supply)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}