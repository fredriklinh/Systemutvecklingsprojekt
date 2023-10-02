using Entiteter;
using Datalager.Seed;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Authentication.ExtendedProtection;
using Entiteter.Personer;
using Entiteter.Tjänster;
using Entiteter.Prislistor;

namespace Datalager.Context
{
    public class dbContext : DbContext
    {
        public dbContext() { }
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=sqlutb2-db.hb.se, 56077;Database=suht2303; TrustServerCertificate=True; user id = suht2303 ;Password=lagg99; MultipleActiveResultSets=true;");
            base.OnConfiguring(optionsBuilder);

        }
        public void Reset()
        {
            #region Remove Tables
            using (SqlConnection conn = new SqlConnection(@"Server=sqlutb2-db.hb.se, 56077;Database=suht2303; TrustServerCertificate=True; user id = suht2303 ;Password=lagg99;MultipleActiveResultSets=true;"))
            using (SqlCommand cmd = new SqlCommand("EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; EXEC sp_msforeachtable 'DROP TABLE ?'", conn))
            {
                conn.Open();
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {
                        // throw;
                    }
                }
                conn.Close();
            }
            #endregion
        }

        public DbSet<Användare> Användare { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Användare>()
            .HasKey(a => a.Användarnamn);


            modelBuilder.Entity<MasterBokning>()
            .HasKey(m => m.BokningsNr);
            modelBuilder.Entity<MasterBokning>().HasOne<Privatkund>(pk => pk.Privatkund);
            modelBuilder.Entity<MasterBokning>().HasOne<Företagskund>(pk => pk.Företagskund);
            modelBuilder.Entity<MasterBokning>().HasOne<Användare>(pk => pk.Användare);

            modelBuilder.Entity<Logi>()
            .HasKey(l => l.LogiId);
            modelBuilder.Entity<Logi>().HasOne<LogiTyp>(l => l.LogiTyp);

            modelBuilder.Entity<PrislistaLogi>()
            .HasKey(p => p.PrisId);

            modelBuilder.Entity<LogiTyp>()
            .HasKey(t => t.LogiTypId);
            modelBuilder.Entity<LogiTyp>().HasMany<Logi>(t => t.Logier);

            modelBuilder.Entity<Faktura>()
            .HasKey(f => f.FakturaId);

            modelBuilder.Entity<PrislistaLogi>()
            .HasKey(p => p.PrisId);

            modelBuilder.Entity<Företagskund>()
            .HasKey(fö => fö.OrgNr);
            modelBuilder.Entity<Företagskund>().HasMany<MasterBokning>(pk => pk.MasterBokningar);

            modelBuilder.Entity<Privatkund>()
            .HasKey(pk => pk.Personnummer);
            modelBuilder.Entity<Privatkund>().HasMany<MasterBokning>(pk => pk.MasterBokningar);



            //här ska klassernas associationer hanteras beroende på dess multiplicitet.
            modelBuilder.Populate();


        }
        
    }
}