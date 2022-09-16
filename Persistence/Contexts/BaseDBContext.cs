using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDBContext: DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public virtual DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }

        public BaseDBContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // if (!optionsBuilder.IsConfigured)
           //     base.OnConfiguring(
           //         optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaIODevsConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tablolar oluşturulurken modelleri bu şekilde tablolarla bağlamak daha sağlıklı bir yöntem.
            // Hangi property hangi sütuna karşılık geliyor.
            modelBuilder.Entity<ProgramingLanguage>(a =>
            {
                a.ToTable("ProgramingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.ProgramingLanguageTechnologies);
            });

            modelBuilder.Entity<ProgramingLanguageTechnology>(a =>
            {
                a.ToTable("ProgramingLanguageTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.programingLanguageId).HasColumnName("ProgramingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgramingLanguage);
            });

            // Tablo oluşturulduğunda 1-2 tane örnek veri eklesin. Seed = Tohum demek.
            ProgramingLanguage[] programingLanguageEntitySeeds = 
            { 
                new(1, "Php"),
                new(2, "Java") 
            };
            modelBuilder.Entity<ProgramingLanguage>().HasData(programingLanguageEntitySeeds);

            ProgramingLanguageTechnology[] programingLanguageTechnologyEntitySeeds =
            {
                new(1, ".Net Core", 3),
                new(2, ".Net MVC", 3)
            };
            modelBuilder.Entity<ProgramingLanguageTechnology>().HasData(programingLanguageTechnologyEntitySeeds);

        }
    }
}
