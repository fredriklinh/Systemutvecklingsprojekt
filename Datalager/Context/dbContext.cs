using Entiteter;
using Datalager.Seed;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Authentication.ExtendedProtection;
using Entiteter.Personer;

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
            .HasKey(e => e.Användarnamn);

            //modelBuilder.Entity<Bokning>()
            //    .HasKey(bk => bk.BokningId);

            //modelBuilder.Entity<Medlem>()
            //    .HasKey(m => m.MedlemsId);

            //modelBuilder.Entity<Faktura>()
            //    .HasKey(f => f.FakturaId);

            //modelBuilder.Entity<Bok>()
            //    .HasKey(b => b.Id);


            //här ska klassernas associationer hanteras beroende på dess multiplicitet.
            modelBuilder.Populate();
        }
    }
}