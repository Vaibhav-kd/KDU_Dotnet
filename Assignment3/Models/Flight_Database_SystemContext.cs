using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment3.Models
{
    public partial class Flight_Database_SystemContext : DbContext
    {
        public Flight_Database_SystemContext()
        {
        }

        public Flight_Database_SystemContext(DbContextOptions<Flight_Database_SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; } = null!;
        public virtual DbSet<Airplane> Airplanes { get; set; } = null!;
        public virtual DbSet<Airport> Airports { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<ContactDetail> ContactDetails { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<FlightInstance> FlightInstances { get; set; } = null!;
        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<RoutePlane> RoutePlanes { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Flight_Database_System;Trusted_Connection=true;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.HasKey(e => e.AirlineCode);

                entity.ToTable("AIRLINE");

                entity.Property(e => e.AirlineCode)
                    .ValueGeneratedNever()
                    .HasColumnName("AIRLINE_CODE");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AIRLINE_NAME");
            });

            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.ToTable("AIRPLANE");

                entity.Property(e => e.AirplaneId)
                    .ValueGeneratedNever()
                    .HasColumnName("AIRPLANE_ID");

                entity.Property(e => e.BSeats).HasColumnName("B_SEATS");

                entity.Property(e => e.ESeats).HasColumnName("E_SEATS");

                entity.Property(e => e.FSeats).HasColumnName("F_SEATS");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.IataAirportCode);

                entity.ToTable("AIRPORT");

                entity.Property(e => e.IataAirportCode)
                    .ValueGeneratedNever()
                    .HasColumnName("IATA_AIRPORT_CODE");

                entity.Property(e => e.AirportName)
                    .HasMaxLength(10)
                    .HasColumnName("AIRPORT_NAME")
                    .IsFixedLength();

                entity.Property(e => e.CityCode).HasColumnName("CITY CODE");

                entity.Property(e => e.CountryCode).HasColumnName("COUNTRY_CODE");

                entity.HasOne(d => d.CityCodeNavigation)
                    .WithMany(p => p.Airports)
                    .HasForeignKey(d => d.CityCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AIRPORT_CITY");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Airports)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AIRPORT_COUNTRY");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IataCityCode);

                entity.ToTable("CITY");

                entity.Property(e => e.IataCityCode)
                    .ValueGeneratedNever()
                    .HasColumnName("IATA_CITY_CODE");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CITY_NAME");

                entity.Property(e => e.CountryCode).HasColumnName("COUNTRY_CODE");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CITY_COUNTRY");
            });

            modelBuilder.Entity<ContactDetail>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("CONTACT_DETAILS");

                entity.Property(e => e.ContactId)
                    .ValueGeneratedNever()
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Line1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LINE1");

                entity.Property(e => e.Phone).HasColumnName("PHONE");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATE");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryIataCode);

                entity.ToTable("COUNTRY");

                entity.Property(e => e.CountryIataCode)
                    .ValueGeneratedNever()
                    .HasColumnName("COUNTRY_IATA_Code");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Country_name");
            });

            modelBuilder.Entity<FlightInstance>(entity =>
            {
                entity.HasKey(e => e.InstanceId);

                entity.ToTable("FLIGHT_INSTANCES");

                entity.Property(e => e.InstanceId)
                    .ValueGeneratedNever()
                    .HasColumnName("INSTANCE_ID");

                entity.Property(e => e.Arrival)
                    .HasColumnType("datetime")
                    .HasColumnName("ARRIVAL");

                entity.Property(e => e.BCost).HasColumnName("B_COST");

                entity.Property(e => e.BSeats).HasColumnName("B_SEATS");

                entity.Property(e => e.Departure)
                    .HasColumnType("datetime")
                    .HasColumnName("DEPARTURE");

                entity.Property(e => e.ECost).HasColumnName("E_COST");

                entity.Property(e => e.ESeats).HasColumnName("E_SEATS");

                entity.Property(e => e.FCost).HasColumnName("F_COST");

                entity.Property(e => e.FSeats).HasColumnName("F_SEATS");

                entity.Property(e => e.PlaneId).HasColumnName("PLANE_ID");

                entity.Property(e => e.RouteId).HasColumnName("ROUTE_ID");

                entity.HasOne(d => d.Plane)
                    .WithMany(p => p.FlightInstances)
                    .HasForeignKey(d => d.PlaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLIGHT_INSTANCES_AIRPLANE");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.FlightInstances)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLIGHT_INSTANCES_ROUTE_PLANE");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("PASSENGERS");

                entity.Property(e => e.PassengerId)
                    .ValueGeneratedNever()
                    .HasColumnName("PASSENGER_ID");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(10)
                    .HasColumnName("CANCELLED")
                    .IsFixedLength();

                entity.Property(e => e.Confirmed)
                    .HasMaxLength(10)
                    .HasColumnName("CONFIRMED")
                    .IsFixedLength();

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ID");

                entity.Property(e => e.FlightInstId).HasColumnName("FLIGHT_INST_ID");

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSENGER_NAME");

                entity.Property(e => e.Phone).HasColumnName("PHONE");

                entity.Property(e => e.SeatNo).HasColumnName("SEAT_NO");

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .HasColumnName("SEX")
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.FlightInst)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.FlightInstId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PASSENGERS_FLIGHT_INSTANCES");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PASSENGERS_USERS");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("ROUTES");

                entity.Property(e => e.RouteId)
                    .ValueGeneratedNever()
                    .HasColumnName("ROUTE_ID");

                entity.Property(e => e.AirlineCode).HasColumnName("AIRLINE_CODE");

                entity.Property(e => e.ArrivalAirportCode).HasColumnName("ARRIVAL_AIRPORT_CODE");

                entity.Property(e => e.DeparureAirportCode).HasColumnName("DEPARURE_AIRPORT_CODE");

                entity.HasOne(d => d.AirlineCodeNavigation)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.AirlineCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROUTES_AIRLINE");

                entity.HasOne(d => d.ArrivalAirportCodeNavigation)
                    .WithMany(p => p.RouteArrivalAirportCodeNavigations)
                    .HasForeignKey(d => d.ArrivalAirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROUTES_AIRPORT1");

                entity.HasOne(d => d.DeparureAirportCodeNavigation)
                    .WithMany(p => p.RouteDeparureAirportCodeNavigations)
                    .HasForeignKey(d => d.DeparureAirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROUTES_AIRPORT");
            });

            modelBuilder.Entity<RoutePlane>(entity =>
            {
                entity.HasKey(e => e.RouteId);

                entity.ToTable("ROUTE_PLANE");

                entity.Property(e => e.RouteId)
                    .ValueGeneratedNever()
                    .HasColumnName("ROUTE_ID");

                entity.Property(e => e.PlaneId).HasColumnName("PLANE_ID");

                entity.HasOne(d => d.Plane)
                    .WithMany(p => p.RoutePlanes)
                    .HasForeignKey(d => d.PlaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROUTE_PLANE_AIRPLANE");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("TRANSACTIONS");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("DATE");

                entity.Property(e => e.Gateway)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GATEWAY");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_MODE");

                entity.Property(e => e.Respcode).HasColumnName("RESPCODE");

                entity.Property(e => e.Respmsg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESPMSG");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANSACTIONS_USERS");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.ContactId).HasColumnName("CONTACT_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERS_CONTACT_DETAILS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
