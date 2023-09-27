using Entiteter;
using Entiteter.Tjänster;
using Entiteter.Prislistor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entiteter.Personer;


namespace Datalager.Seed
{
    public static class Seed
    {
        public static void Populate(this ModelBuilder modelBuilder)
        {

            
                modelBuilder.Entity<Användare>().HasData(
                    new Användare() 
                    { 
                        AnvändarID = 99, 
                        Behörighetsnivå = 1, 
                        Användarnamn = "Magnus", 
                        Lösenord = "a", 
                        Efternamn = "Otterberg", 
                        Förnamn = "Magnifike" 
                    }
                    );

            modelBuilder.Entity<PrislistaLogi>().HasData(new PrislistaLogi()
            {
                PrisId = 1,
                TypAvLogi = "Ll1",
                Vecka = 1,
                PrisVardag = 415,
                PrisHelg = 725,
                PrisVecka = 2895, 
            });
           
        }


    }







}
