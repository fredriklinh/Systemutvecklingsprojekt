using Datalager.Seed;
using Entiteter.Personer;
using Entiteter.Prislistor;
using Entiteter.Tjänster;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Systemutvecklingsprojekt;Integrated Security=True;MultipleActiveResultSets=true;"/*@"Server=sqlutb2-db.hb.se, 56077;Database=suht2303; TrustServerCertificate=True; user id = suht2303 ;Password=lagg99; MultipleActiveResultSets=true;"*/);
            base.OnConfiguring(optionsBuilder);

        }
        public void Reset()
        {


            #region Remove Tables
            using (SqlConnection conn = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=Systemutvecklingsprojekt;Integrated Security=True;MultipleActiveResultSets=true;"/*@"Server=sqlutb2-db.hb.se, 56077;Database=suht2303; TrustServerCertificate=True; user id = suht2303 ;Password=lagg99;MultipleActiveResultSets=true;"*/))
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Användare + Masterbokning
            modelBuilder.Entity<Användare>()
            .HasKey(a => a.Användarnamn);

            modelBuilder.Entity<MasterBokning>()
            .HasKey(m => m.BokningsNr);
            modelBuilder.Entity<MasterBokning>().HasOne<Privatkund>(pk => pk.Privatkund);
            modelBuilder.Entity<MasterBokning>().HasOne<Företagskund>(pk => pk.Företagskund);
            modelBuilder.Entity<MasterBokning>().HasOne<Användare>(pk => pk.Användare);
            modelBuilder.Entity<MasterBokning>().HasMany<UtrustningsBokning>();
            #endregion

            #region Logi + LogiTyp + Faktura
            modelBuilder.Entity<Logi>()
            .HasKey(l => l.LogiId);
            modelBuilder.Entity<Logi>().HasOne<LogiTyp>(l => l.LogiTyp);
            //modelBuilder.Entity<Logi>().HasMany<MasterBokning>();

            modelBuilder.Entity<LogiTyp>()
            .HasKey(t => t.LogiTypId);

            modelBuilder.Entity<LogiTyp>().HasMany<Logi>(t => t.Logier);

            modelBuilder.Entity<Faktura>()
            .HasKey(f => f.FakturaId);
            #endregion

            #region Privat & Företagskund
            modelBuilder.Entity<Företagskund>()
            .HasKey(fö => fö.OrgNr);
            modelBuilder.Entity<Företagskund>().HasMany<MasterBokning>(pk => pk.MasterBokningar);

            modelBuilder.Entity<Privatkund>()
            .HasKey(pk => pk.Personnummer);
            modelBuilder.Entity<Privatkund>().HasMany<MasterBokning>(pk => pk.MasterBokningar);
            #endregion

            #region Prislistor
            modelBuilder.Entity<PrislistaLogi>()
                .HasKey(p => p.PrisId);
            modelBuilder.Entity<PrisListaKonferens>()
                .HasKey(plk => plk.PrisId);
            modelBuilder.Entity<PrisListaUtrustning>()
                .HasKey(plu => plu.PrisId);

            #endregion


            #region Utrustning
            modelBuilder.Entity<Utrustning>()
                .HasKey(u => u.UtrustningsId);
            modelBuilder.Entity<Utrustning>().HasOne<UtrustningsTyp>(u => u.UtrustningsTyp);

            modelBuilder.Entity<UtrustningsBokning>()
           .HasKey(utb => utb.UtrustningBokningsId);
            modelBuilder.Entity<UtrustningsBokning>().HasMany<Utrustning>(u => u.Utrustningar);
            modelBuilder.Entity<UtrustningsBokning>().HasOne<MasterBokning>(u => u.MasterBokning);
            modelBuilder.Entity<UtrustningsBokning>().HasOne<Faktura>(u => u.Faktura);

            modelBuilder.Entity<UtrustningsTyp>()
           .HasKey(ut => ut.Typ);
            modelBuilder.Entity<UtrustningsTyp>().HasMany<Utrustning>(u => u.Utrustning);

            #endregion


            #region Lektioner + Relaterat
            modelBuilder.Entity<PrivatLektion>()
            .HasKey(pl => pl.ID);

            modelBuilder.Entity<GruppLektion>()
            .HasKey(gl => gl.ID);

            modelBuilder.Entity<Elev>()
            .HasKey(e => e.ID);

            modelBuilder.Entity<Personal>()
            .HasKey(p => p.AnstNr);
            #endregion

            #region Konferenslokal + Relaterat
            modelBuilder.Entity<Konferenslokal>()
            .HasKey(kl => kl.KonferensBenämningsId);

            #endregion
            //här ska klassernas associationer hanteras beroende på dess multiplicitet.
            modelBuilder.Populate();


        }

    }
}