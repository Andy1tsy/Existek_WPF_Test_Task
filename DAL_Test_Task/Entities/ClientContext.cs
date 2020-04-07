using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL_Test_Task.Entities
{
    public partial class ClientContext : DbContext
    {
        public ClientContext()
        {
        }

        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Greeting> Greeting { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonContact> PersonContact { get; set; }
        public string connectionString = "server=localhost;port=3306;user=root;password=qwe123;database=test_db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql(connectionString, x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("country");

                entity.HasIndex(e => e.Txt1)
                    .HasName("UK_TXT1")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasColumnType("char(2)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("'1'")
                    .HasComment("0: inactive, 1: active");

                entity.Property(e => e.AddrFormatId)
                    .HasColumnName("ADDR_FORMAT_ID")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1: CountryCode / Zip / City, 2: Zip / City / Country, 3: City / Zip / Country");

                entity.Property(e => e.IntDialCode)
                    .HasColumnName("INT_DIAL_CODE")
                    .HasColumnType("char(10)")
                    .HasComment("international dial code")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsVatIncluded)
                    .HasColumnName("IS_VAT_INCLUDED")
                    .HasDefaultValueSql("'1'")
                    .HasComment("0: no, 1: yes - for future use");

                entity.Property(e => e.Txt1)
                    .IsRequired()
                    .HasColumnName("TXT1")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Txt2)
                    .HasColumnName("TXT2")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Txt3)
                    .HasColumnName("TXT3")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Txt4)
                    .HasColumnName("TXT4")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Greeting>(entity =>
            {
                entity.ToTable("greeting");

                entity.HasIndex(e => e.Txt1)
                    .HasName("UK_TXT1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("'1'")
                    .HasComment("0: inactive, 1: active");

                entity.Property(e => e.Txt1)
                    .IsRequired()
                    .HasColumnName("TXT1")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Txt2)
                    .HasColumnName("TXT2")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Txt3)
                    .HasColumnName("TXT3")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Txt4)
                    .HasColumnName("TXT4")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TxtLetter1)
                    .IsRequired()
                    .HasColumnName("TXT_LETTER1")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TxtLetter2)
                    .HasColumnName("TXT_LETTER2")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TxtLetter3)
                    .HasColumnName("TXT_LETTER3")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TxtLetter4)
                    .HasColumnName("TXT_LETTER4")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => e.City)
                    .HasName("IDX_CITY");

                entity.HasIndex(e => e.CountryCode)
                    .HasName("FK_person_country");

                entity.HasIndex(e => e.Cpny)
                    .HasName("IDX_CPNY");

                entity.HasIndex(e => e.GreetingId)
                    .HasName("FK_person_greeting");

                entity.HasIndex(e => e.Lname)
                    .HasName("IDX_NAME");

                entity.HasIndex(e => e.Zip)
                    .HasName("IDX_ZIP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("COUNTRY_CODE")
                    .HasColumnType("char(2)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Cpny)
                    .HasColumnName("CPNY")
                    .HasColumnType("varchar(255)")
                    .HasComment("NAME or CPNY are mandatory; must be ensured by application")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("DATE_OF_BIRTH")
                    .HasColumnType("date");

                entity.Property(e => e.FirstContact)
                    .HasColumnName("FIRST_CONTACT")
                    .HasColumnType("date")
                    .HasComment("Record creation / Set on insert");

                entity.Property(e => e.Fname)
                    .HasColumnName("FNAME")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.GenderId)
                    .HasColumnName("GENDER_ID")
                    .HasComment("1: without, 2: male, 3: female, 4: other");

                entity.Property(e => e.GreetingId).HasColumnName("GREETING_ID");

                entity.Property(e => e.Lname)
                    .HasColumnName("LNAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("NAME or CPNY are mandatory; must be ensured by application")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Street)
                    .HasColumnName("STREET")
                    .HasColumnType("text")
                    .HasComment("multiline")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Zip)
                    .HasColumnName("ZIP")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_country");

                entity.HasOne(d => d.Greeting)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GreetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_greeting");
            });

            modelBuilder.Entity<PersonContact>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.PersonContactId })
                    .HasName("PRIMARY");

                entity.ToTable("person_contact");

                entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");

                entity.Property(e => e.PersonContactId)
                    .HasColumnName("PERSON_CONTACT_ID")
                    .HasComment("part of primary key");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("'1'")
                    .HasComment("0: inactive, 1: active");

                entity.Property(e => e.ContactTypeId).HasColumnName("CONTACT_TYPE_ID");

                entity.Property(e => e.Notes)
                    .HasColumnName("NOTES")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Txt)
                    .HasColumnName("TXT")
                    .HasColumnType("text")
                    .HasComment("e.g. phone number")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonContact)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_person_contact_person");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
