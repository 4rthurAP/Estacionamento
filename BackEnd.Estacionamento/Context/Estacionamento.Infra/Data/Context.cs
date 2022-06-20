using Estacionamento.Domain.Models.Bussiness;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Infra.Data
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clientes { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Valuehour> Valuehours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("CLIENTE");

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

                entity.Property(e => e.Car)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CAR");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Plate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PLATE");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TimeIn).HasColumnName("TIMEIN");

                entity.Property(e => e.TimeOut).HasColumnName("TIMEOUT");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("LOG");

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

                entity.Property(e => e.Car)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CAR");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Plate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PLATE");

                entity.Property(e => e.Host)
                    .HasMaxLength(30)
                    .HasColumnName("Host");

                entity.Property(e => e.Objeto)
                   .HasMaxLength(2000000)
                   .HasColumnName("Host");

                entity.Property(e => e.Path)
                   .HasMaxLength(2000000)
                   .HasColumnName("Host");

                entity.Property(e => e.Trace)
                   .HasMaxLength(2000000)
                   .HasColumnName("Host");

                entity.Property(e => e.TimeIn).HasColumnName("TIMEIN");

                entity.Property(e => e.TimeOut).HasColumnName("TIMEOUT");
            });

            modelBuilder.Entity<Valuehour>(entity =>
            {
                entity.ToTable("VALUEHOUR");

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

                entity.Property(e => e.Time).HasColumnName("TIME");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("VALUE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
