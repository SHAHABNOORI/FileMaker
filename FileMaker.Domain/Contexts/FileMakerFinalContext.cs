using FileMaker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FileMaker.Domain.Contexts
{
    public class FileMakerFinalContext : DbContext
    {
        public FileMakerFinalContext()
        {
        }

        public FileMakerFinalContext(DbContextOptions<FileMakerFinalContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Origin> Origins { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<ClientContact> ClientContacts { get; set; }

        public DbSet<ClientAddress> ClientAddresses { get; set; }

        public DbSet<ClientDeliveryAddress> ClientDeliveryAddresses { get; set; }

        public DbSet<ClientPurchase> ClientPurchases { get; set; }

        public DbSet<ClientExtraInformation> ClientExtraInformations { get; set; }

        public DbSet<ClientPayment> ClientPayments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Degree> Degrees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientCode);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber);
            });

            modelBuilder.Entity<ClientContact>(entity =>
            {
                entity.HasKey(e => e.ClientContactId);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.SkillId);
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.HasKey(e => e.DegreeId);
            });

            modelBuilder.Entity<Client>()
                .HasOne(a => a.ClientContact)
                .WithOne(b => b.Client)
                .HasForeignKey<ClientContact>(b => b.ClientCode);


            modelBuilder.Entity<ClientAddress>(entity =>
            {
                entity.HasKey(e => e.ClientAddressId);
            });

            modelBuilder.Entity<Client>()
                .HasOne(a => a.ClientAddress)
                .WithOne(b => b.Client)
                .HasForeignKey<ClientAddress>(b => b.ClientCode);


            modelBuilder.Entity<ClientDeliveryAddress>(entity =>
            {
                entity.HasKey(e => e.ClientDeliveryAddressId);
            });

            modelBuilder.Entity<Client>()
                .HasOne(a => a.ClientDeliveryAddress)
                .WithOne(b => b.Client)
                .HasForeignKey<ClientDeliveryAddress>(b => b.ClientCode);

            modelBuilder.Entity<ClientPurchase>(entity =>
            {
                entity.HasKey(e => e.ClientPurchaseId);
            });

            modelBuilder.Entity<Client>()
                .HasOne(a => a.ClientPurchase)
                .WithOne(b => b.Client)
                .HasForeignKey<ClientPurchase>(b => b.ClientCode);


            modelBuilder.Entity<ClientExtraInformation>(entity =>
            {
                entity.HasKey(e => e.ClientExtraInformationId);
            });

            modelBuilder.Entity<Client>()
                .HasOne(a => a.ClientExtraInformation)
                .WithOne(b => b.Client)
                .HasForeignKey<ClientExtraInformation>(b => b.ClientCode);

            modelBuilder.Entity<ClientPayment>(entity =>
            {
                entity.HasKey(e => e.ClientPaymentId);
            });

            modelBuilder.Entity<Client>()
                .HasOne(a => a.ClientPayment)
                .WithOne(b => b.Client)
                .HasForeignKey<ClientPayment>(b => b.ClientCode);


            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(es => new { es.EmployeeNumber, es.SkillId });
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(es => es.Employee)
                .WithMany(b => b.EmployeeSkills)
                .HasForeignKey(bc => bc.EmployeeNumber);
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(es => es.Skill)
                .WithMany(c => c.EmployeeSkills)
                .HasForeignKey(bc => bc.SkillId);


            modelBuilder.Entity<EmployeeDegree>()
                .HasKey(es => new { es.EmployeeNumber, es.DegreeId });
            modelBuilder.Entity<EmployeeDegree>()
                .HasOne(es => es.Employee)
                .WithMany(b => b.EmployeeDegrees)
                .HasForeignKey(bc => bc.EmployeeNumber);
            modelBuilder.Entity<EmployeeDegree>()
                .HasOne(es => es.Degree)
                .WithMany(c => c.EmployeeDegrees)
                .HasForeignKey(bc => bc.DegreeId);
        }
    }
}
