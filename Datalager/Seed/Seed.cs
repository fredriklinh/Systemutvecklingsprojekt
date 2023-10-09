using Entiteter.Personer;
using Entiteter.Prislistor;
using Entiteter.Tjänster;
using Microsoft.EntityFrameworkCore;

namespace Datalager.Seed
{
    public static class Seed
    {
        public static void Populate(this ModelBuilder modelBuilder)
        {

            #region Ladda användare
            modelBuilder.Entity<Användare>().HasData(
                new Användare()
                {
                    AnvändarID = 55,
                    Behörighetsnivå = 1,
                    Användarnamn = "Anders",
                    Lösenord = "a",
                    Efternamn = "Otterberg",
                    Förnamn = "Magnifike"
                }
                );
            #endregion Ladda användare


            #region Ladda Logi
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 1,
                TypAvLogi = "LGH.I",
                Vecka = 1,
                PrisVardag = 415,
                PrisHelg = 725,
                PrisVecka = 2895,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 2,
                TypAvLogi = "LGH.I",
                Vecka = 2,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 3,
                TypAvLogi = "LGH.I",
                Vecka = 3,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 4,
                TypAvLogi = "LGH.I",
                Vecka = 4,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 5,
                TypAvLogi = "LGH.I",
                Vecka = 5,
                PrisVardag = 270,
                PrisHelg = 410,
                PrisVecka = 1895,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 6,
                TypAvLogi = "LGH.I",
                Vecka = 6,
                PrisVardag = 270,
                PrisHelg = 410,
                PrisVecka = 1895,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 7,
                TypAvLogi = "LGH.I",
                Vecka = 7,
                PrisVardag = 0,
                PrisHelg = 0,
                PrisVecka = 3895,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 8,
                TypAvLogi = "LGH.I",
                Vecka = 8,
                PrisVardag = 0,
                PrisHelg = 0,
                PrisVecka = 3895,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 9,
                TypAvLogi = "LGH.I",
                Vecka = 9,
                PrisVardag = 415,
                PrisHelg = 725,
                PrisVecka = 2895,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 10,
                TypAvLogi = "LGH.I",
                Vecka = 10,
                PrisVardag = 300,
                PrisHelg = 455,
                PrisVecka = 2095,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 11,
                TypAvLogi = "LGH.I",
                Vecka = 11,
                PrisVardag = 300,
                PrisHelg = 455,
                PrisVecka = 2095,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 12,
                TypAvLogi = "LGH.I",
                Vecka = 12,
                PrisVardag = 300,
                PrisHelg = 455,
                PrisVecka = 2095,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 13,
                TypAvLogi = "LGH.I",
                Vecka = 13,
                PrisVardag = 415,
                PrisHelg = 725,
                PrisVecka = 2895,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 14,
                TypAvLogi = "LGH.I",
                Vecka = 14,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 15,
                TypAvLogi = "LGH.I",
                Vecka = 15,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 16,
                TypAvLogi = "LGH.I",
                Vecka = 16,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 17,
                TypAvLogi = "LGH.I",
                Vecka = 17,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 18,
                TypAvLogi = "LGH.I",
                Vecka = 18,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 19,
                TypAvLogi = "LGH.I",
                Vecka = 19,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 20,
                TypAvLogi = "LGH.I",
                Vecka = 20,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 21,
                TypAvLogi = "LGH.I",
                Vecka = 21,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 22,
                TypAvLogi = "LGH.I",
                Vecka = 22,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 23,
                TypAvLogi = "LGH.I",
                Vecka = 23,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 24,
                TypAvLogi = "LGH.I",
                Vecka = 24,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 25,
                TypAvLogi = "LGH.I",
                Vecka = 25,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 26,
                TypAvLogi = "LGH.I",
                Vecka = 26,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 27,
                TypAvLogi = "LGH.I",
                Vecka = 27,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 28,
                TypAvLogi = "LGH.I",
                Vecka = 28,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 29,
                TypAvLogi = "LGH.I",
                Vecka = 29,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 30,
                TypAvLogi = "LGH.I",
                Vecka = 30,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 31,
                TypAvLogi = "LGH.I",
                Vecka = 31,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 32,
                TypAvLogi = "LGH.I",
                Vecka = 32,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 33,
                TypAvLogi = "LGH.I",
                Vecka = 33,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 34,
                TypAvLogi = "LGH.I",
                Vecka = 34,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 35,
                TypAvLogi = "LGH.I",
                Vecka = 35,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 36,
                TypAvLogi = "LGH.I",
                Vecka = 36,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 37,
                TypAvLogi = "LGH.I",
                Vecka = 37,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 38,
                TypAvLogi = "LGH.I",
                Vecka = 38,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 39,
                TypAvLogi = "LGH.I",
                Vecka = 39,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 40,
                TypAvLogi = "LGH.I",
                Vecka = 40,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 41,
                TypAvLogi = "LGH.I",
                Vecka = 41,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 42,
                TypAvLogi = "LGH.I",
                Vecka = 42,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 43,
                TypAvLogi = "LGH.I",
                Vecka = 43,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 44,
                TypAvLogi = "LGH.I",
                Vecka = 44,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 45,
                TypAvLogi = "LGH.I",
                Vecka = 45,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 46,
                TypAvLogi = "LGH.I",
                Vecka = 46,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 47,
                TypAvLogi = "LGH.I",
                Vecka = 47,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 48,
                TypAvLogi = "LGH.I",
                Vecka = 48,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 49,
                TypAvLogi = "LGH.I",
                Vecka = 49,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 50,
                TypAvLogi = "LGH.I",
                Vecka = 50,
                PrisVardag = 200,
                PrisHelg = 200,
                PrisVecka = 1300,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 51,
                TypAvLogi = "LGH.I",
                Vecka = 51,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 52,
                TypAvLogi = "LGH.I",
                Vecka = 52,
                PrisVardag = 240,
                PrisHelg = 370,
                PrisVecka = 1695,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 53,
                TypAvLogi = "LGH.II",
                Vecka = 1,
                PrisVardag = 555,
                PrisHelg = 975,
                PrisVecka = 3895,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 54,
                TypAvLogi = "LGH.II",
                Vecka = 2,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 55,
                TypAvLogi = "LGH.II",
                Vecka = 3,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 56,
                TypAvLogi = "LGH.II",
                Vecka = 4,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 57,
                TypAvLogi = "LGH.II",
                Vecka = 5,
                PrisVardag = 370,
                PrisHelg = 565,
                PrisVecka = 2595,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 58,
                TypAvLogi = "LGH.II",
                Vecka = 6,
                PrisVardag = 370,
                PrisHelg = 565,
                PrisVecka = 2595,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 59,
                TypAvLogi = "LGH.II",
                Vecka = 7,
                PrisVardag = 0,
                PrisHelg = 0,
                PrisVecka = 4995,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 60,
                TypAvLogi = "LGH.II",
                Vecka = 8,
                PrisVardag = 0,
                PrisHelg = 0,
                PrisVecka = 4995,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 156,
                TypAvLogi = "LGH.II",
                Vecka = 9,
                PrisVardag = 555,
                PrisHelg = 975,
                PrisVecka = 3895,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 61,
                TypAvLogi = "LGH.II",
                Vecka = 10,
                PrisVardag = 440,
                PrisHelg = 670,
                PrisVecka = 3095,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 62,
                TypAvLogi = "LGH.II",
                Vecka = 11,
                PrisVardag = 440,
                PrisHelg = 670,
                PrisVecka = 3095,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 63,
                TypAvLogi = "LGH.II",
                Vecka = 12,
                PrisVardag = 440,
                PrisHelg = 670,
                PrisVecka = 3095,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 157,
                TypAvLogi = "LGH.II",
                Vecka = 13,
                PrisVardag = 555,
                PrisHelg = 975,
                PrisVecka = 3895,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 64,
                TypAvLogi = "LGH.II",
                Vecka = 14,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 65,
                TypAvLogi = "LGH.II",
                Vecka = 15,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 66,
                TypAvLogi = "LGH.II",
                Vecka = 16,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 67,
                TypAvLogi = "LGH.II",
                Vecka = 17,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 68,
                TypAvLogi = "LGH.II",
                Vecka = 18,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 69,
                TypAvLogi = "LGH.II",
                Vecka = 19,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 70,
                TypAvLogi = "LGH.II",
                Vecka = 20,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 71,
                TypAvLogi = "LGH.II",
                Vecka = 21,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 72,
                TypAvLogi = "LGH.II",
                Vecka = 22,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 73,
                TypAvLogi = "LGH.II",
                Vecka = 23,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 74,
                TypAvLogi = "LGH.II",
                Vecka = 24,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 75,
                TypAvLogi = "LGH.II",
                Vecka = 25,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 76,
                TypAvLogi = "LGH.II",
                Vecka = 26,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 77,
                TypAvLogi = "LGH.II",
                Vecka = 27,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 78,
                TypAvLogi = "LGH.II",
                Vecka = 28,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 79,
                TypAvLogi = "LGH.II",
                Vecka = 29,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 80,
                TypAvLogi = "LGH.II",
                Vecka = 30,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 81,
                TypAvLogi = "LGH.II",
                Vecka = 31,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 82,
                TypAvLogi = "LGH.II",
                Vecka = 32,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 83,
                TypAvLogi = "LGH.II",
                Vecka = 33,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 84,
                TypAvLogi = "LGH.II",
                Vecka = 34,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 85,
                TypAvLogi = "LGH.II",
                Vecka = 35,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 86,
                TypAvLogi = "LGH.II",
                Vecka = 36,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 87,
                TypAvLogi = "LGH.II",
                Vecka = 37,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 88,
                TypAvLogi = "LGH.II",
                Vecka = 38,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 89,
                TypAvLogi = "LGH.II",
                Vecka = 39,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 90,
                TypAvLogi = "LGH.II",
                Vecka = 40,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 91,
                TypAvLogi = "LGH.II",
                Vecka = 41,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 92,
                TypAvLogi = "LGH.II",
                Vecka = 42,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 93,
                TypAvLogi = "LGH.II",
                Vecka = 43,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 94,
                TypAvLogi = "LGH.II",
                Vecka = 44,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 95,
                TypAvLogi = "LGH.II",
                Vecka = 45,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 96,
                TypAvLogi = "LGH.II",
                Vecka = 46,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 97,
                TypAvLogi = "LGH.II",
                Vecka = 47,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 98,
                TypAvLogi = "LGH.II",
                Vecka = 48,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 99,
                TypAvLogi = "LGH.II",
                Vecka = 49,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 100,
                TypAvLogi = "LGH.II",
                Vecka = 50,
                PrisVardag = 230,
                PrisHelg = 230,
                PrisVecka = 1400,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 101,
                TypAvLogi = "LGH.II",
                Vecka = 51,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 102,
                TypAvLogi = "LGH.II",
                Vecka = 52,
                PrisVardag = 330,
                PrisHelg = 495,
                PrisVecka = 2295,
            });
            //blir ett hopp mellan ID 102 och 104 pga tidigare miss med PK(sök 103).
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 104,
                TypAvLogi = "Camp",
                Vecka = 1,
                PrisVardag = 170,
                PrisVecka = 1120,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 105,
                TypAvLogi = "Camp",
                Vecka = 2,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 106,
                TypAvLogi = "Camp",
                Vecka = 3,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 107,
                TypAvLogi = "Camp",
                Vecka = 4,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 108,
                TypAvLogi = "Camp",
                Vecka = 5,
                PrisVardag = 150,
                PrisVecka = 970,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 109,
                TypAvLogi = "Camp",
                Vecka = 6,
                PrisVardag = 150,
                PrisVecka = 970,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 110,
                TypAvLogi = "Camp",
                Vecka = 7,
                PrisVardag = 170,
                PrisVecka = 1120,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 111,
                TypAvLogi = "Camp",
                Vecka = 8,
                PrisVardag = 170,
                PrisVecka = 1120,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 112,
                TypAvLogi = "Camp",
                Vecka = 9,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 113,
                TypAvLogi = "Camp",
                Vecka = 10,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 114,
                TypAvLogi = "Camp",
                Vecka = 11,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 115,
                TypAvLogi = "Camp",
                Vecka = 12,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 116,
                TypAvLogi = "Camp",
                Vecka = 13,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 117,
                TypAvLogi = "Camp",
                Vecka = 14,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 118,
                TypAvLogi = "Camp",
                Vecka = 15,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 119,
                TypAvLogi = "Camp",
                Vecka = 16,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 120,
                TypAvLogi = "Camp",
                Vecka = 17,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 121,
                TypAvLogi = "Camp",
                Vecka = 18,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 122,
                TypAvLogi = "Camp",
                Vecka = 19,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 123,
                TypAvLogi = "Camp",
                Vecka = 20,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 124,
                TypAvLogi = "Camp",
                Vecka = 21,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 158,
                TypAvLogi = "Camp",
                Vecka = 22,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 125,
                TypAvLogi = "Camp",
                Vecka = 23,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 126,
                TypAvLogi = "Camp",
                Vecka = 24,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 127,
                TypAvLogi = "Camp",
                Vecka = 25,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 128,
                TypAvLogi = "Camp",
                Vecka = 26,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 129,
                TypAvLogi = "Camp",
                Vecka = 27,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 130,
                TypAvLogi = "Camp",
                Vecka = 28,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 131,
                TypAvLogi = "Camp",
                Vecka = 29,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 132,
                TypAvLogi = "Camp",
                Vecka = 30,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 133,
                TypAvLogi = "Camp",
                Vecka = 31,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 134,
                TypAvLogi = "Camp",
                Vecka = 32,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 135,
                TypAvLogi = "Camp",
                Vecka = 33,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 136,
                TypAvLogi = "Camp",
                Vecka = 33,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 137,
                TypAvLogi = "Camp",
                Vecka = 34,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 138,
                TypAvLogi = "Camp",
                Vecka = 35,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 139,
                TypAvLogi = "Camp",
                Vecka = 36,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 140,
                TypAvLogi = "Camp",
                Vecka = 37,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 141,
                TypAvLogi = "Camp",
                Vecka = 38,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 142,
                TypAvLogi = "Camp",
                Vecka = 39,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 143,
                TypAvLogi = "Camp",
                Vecka = 40,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 144,
                TypAvLogi = "Camp",
                Vecka = 41,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 145,
                TypAvLogi = "Camp",
                Vecka = 42,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 146,
                TypAvLogi = "Camp",
                Vecka = 43,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 147,
                TypAvLogi = "Camp",
                Vecka = 44,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 148,
                TypAvLogi = "Camp",
                Vecka = 45,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 149,
                TypAvLogi = "Camp",
                Vecka = 46,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 150,
                TypAvLogi = "Camp",
                Vecka = 47,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 151,
                TypAvLogi = "Camp",
                Vecka = 48,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 152,
                TypAvLogi = "Camp",
                Vecka = 49,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 153,
                TypAvLogi = "Camp",
                Vecka = 50,
                PrisVardag = 130,
                PrisVecka = 815,
            });

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 154,
                TypAvLogi = "Camp",
                Vecka = 51,
                PrisVardag = 130,
                PrisVecka = 815,
            });
            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 155,
                TypAvLogi = "Camp",
                Vecka = 52,
                PrisVardag = 130,
                PrisVecka = 815,
            });

            modelBuilder.Entity<LogiTyp>().HasData(new LogiTyp()
            {
                LogiTypId = "LGH.I"

            });

            modelBuilder.Entity<LogiTyp>().HasData(new LogiTyp()
            {
                LogiTypId = "LGH.II"

            });

            modelBuilder.Entity<LogiTyp>().HasData(new LogiTyp()
            {
                LogiTypId = "Camp"

            });


            for (int i = 1; i <= 50; i++)
            {

                modelBuilder.Entity<Logi>().HasData(new Logi()
                {
                    LogiId = "Ll" + i,
                    Kvadratmeter = 50,
                    Bäddar = 4,
                    Kök = true,
                    ÄrTillgänglig = true,
                    Typen = "LGH.I"

                });

            }
            for (int i = 1; i <= 35; i++)
            {

                modelBuilder.Entity<Logi>().HasData(new Logi()
                {
                    LogiId = "Lll" + i,
                    Kvadratmeter = 70,
                    Bäddar = 6,
                    Kök = true,
                    ÄrTillgänglig = true,
                    Typen = "LGH.II"


                });



            }
            #endregion Ladda Logi


            #region Ladda Kund
            modelBuilder.Entity<Privatkund>().HasData(new Privatkund()
            {
                //PrivatkundId = 1,
                Personnummer = "19680314-2322",
                Förnamn = "Fiel",
                Efternamn = "Skogholm",
                Adress = "Tingstadsalé 24",
                Postnummer = "78533",
                Ort = "Stockholm",
                Telefonnummer = "07266555994",
                MailAdress = "Fiel.Skogholm@stocknäs.se"

            });

            modelBuilder.Entity<Privatkund>().HasData(new Privatkund()
            {
                //PrivatkundId = 2,
                Personnummer = "19990523-2322",
                Förnamn = "Fidde",
                Efternamn = "Skoglund",
                Adress = "Tingstadsgatan 24",
                Postnummer = "45839",
                Ort = "Stockholm",
                Telefonnummer = "07366555994",
                MailAdress = "Fiel.Skogholm@stocknäs.se"

            });
            modelBuilder.Entity<Företagskund>().HasData(new Företagskund()
            {
                //FöretagsId = 999,
                OrgNr = "4343-2321",
                FöretagsNamn = "Byggplockarna AB",
                Adress = "Karlatornsväg 23",
                Postnummer = "46941",
                Ort = "Utby",
                Telefonnummer = "07266555994",
                MailAdress = "ByggplockAB@foretagsadress.se",
                RabattSats = 12.5,
                MaxBeloppsKreditGräns = 60000

            });

            #endregion Ladda Kund


            #region Ladda utrustning            
            //Ladda in Alpinskidor
            for (int i = 1; i <= 350; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"AS{+ i}",
                    Tillgänglig = true,
                    Typ = "Alpint",
                    Benämning = "Skidor"
                });              
            }
            //Ladda in Alpinpjäxor
            for (int i = 1; i <= 500; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"AP{+ i}",
                    Tillgänglig = true,
                    Typ = "Alpint",
                    Benämning = "Pjäxor"
                });
            }
            //Ladda in Alpinstavar
            for (int i = 1; i <= 425; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"ASS{+ i}",
                    Tillgänglig = true,
                    Typ = "Alpint",
                    Benämning = "Stavar"
                });
            }
            //Ladda in Längdskidor
            for (int i = 1; i <= 150; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"LS{+ i}",
                    Tillgänglig = true,
                    Typ = "Längd",
                    Benämning = "Skidor"
                });
            }
            //Ladda in Längdpjäxor
            for (int i = 1; i <= 200; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"LP{+ i}",
                    Tillgänglig = true,
                    Typ = "Längd",
                    Benämning = "Pjäxor"
                });
            }
            //Ladda in Längdstavar
            for (int i = 1; i <= 175; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"LSS{+ i}",
                    Tillgänglig = true,
                    Typ = "Längd",
                    Benämning = "Stavar"
                });
            }
            //Ladda in Snowboard
            for (int i = 1; i <= 85; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"SB{+ i}",
                    Tillgänglig = true,
                    Typ = "Snowboard",
                    Benämning = "Snowboard"
                });
            }
            //Ladda in Snowboardskor
            for (int i = 1; i <= 90; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"SS{+ i}",
                    Tillgänglig = true,
                    Typ = "Snowboard",
                    Benämning = "Snowboardskor"
                });
            }
            //Ladda in Snöskoter av märket Lynx
            for (int i = 1; i <= 8; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"S{+ i}",
                    Tillgänglig = true,
                    Typ = "Snöskoter",
                    Benämning = "Lynx 50"
                });
            }
            //Ladda in Snöskoter av märket Yamaha
            for (int i = 9; i <= 15; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"S{+ i}",
                    Tillgänglig = true,
                    Typ = "Snöskoter",
                    Benämning = "Yamaha Vikning"
                });
            }
            //Ladda in Skoterpulka
            for (int i = 1; i <= 15; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"NP{+ i}",
                    Tillgänglig = true,
                    Typ = "Snöskoter",
                    Benämning = "Nilapulka"
                });
            }
            //Ladda in Hjälmar
            for (int i = 1; i <= 600; i++)
            {
                modelBuilder.Entity<Utrustning>().HasData(new Utrustning()
                {
                    UtrustningsId = $"H{+ i}",
                    Tillgänglig = true,
                    Typ = "Hjälm",
                    Benämning = "Hjälm"
                });
            }

            modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            {
                Typ = "Alpint"

            });
            modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            {
                Typ = "Snöskoter"

            });
            modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            {
                Typ = "Snowboard"

            });
            modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            {
                Typ = "Längd"

            });
            modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            {
                Typ = "Hjälm"

            });

            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Alpint Skidor"

            //});
            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Alpint Pjäxor"

            //});
            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Alpint Stavar"

            //});
            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Längd Skidor"

            //});
            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Längd Pjäxor"

            //});
            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Längd Stavar"

            //});
            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Snowboard"

            //});
            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Snowboard skor"

            //});
            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Snöskoter"

            //});
            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Skoterpulka"

            //});
            //modelBuilder.Entity<UtrustningsTyp>().HasData(new UtrustningsTyp()
            //{
            //    UtrustningsTypId = "Hjälm"

            //});


            #endregion Ladda utrustning

            // Test för att se rabatterat pris

            //modelBuilder.Entity<MasterBokning>().HasData(new MasterBokning()
            //{
            //    Avbeställningsskydd = true,
            //    NyttjadKreditsumma = 0,
            //    BokningsDatum = new DateTime(2022, 12, 20),
            //    StartDatum = new DateTime(2022, 12, 25),
            //    SlutDatum = new DateTime(2022, 12, 30),
            //    Privatkund = 
            //});










        }
    }



}








