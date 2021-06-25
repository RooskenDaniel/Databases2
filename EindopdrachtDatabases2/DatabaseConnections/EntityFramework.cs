using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EindopdrachtDatabases2.DatabaseConnections.Entityframework;

namespace EindopdrachtDatabases2.DatabaseConnections
{
    public class EntityFramework : IDBConn
    {
        private bool connected = false;
        private NetflixContext connection;

        public void Connect()
        {
            connection = new NetflixContext();
            connection.Database.EnsureCreated();
            connected = true;
            Console.WriteLine($"Connected to an Entity Framework Core database.\n - EF Provider: {connection.Database.ProviderName.Split('.').Last()}");
        }

        public void Insert(int amount)
        {
            //This method works for 1 row of data
            //More rows are not possible, because it does not recognise connection.Afleveringen.Take(amount)

            var Afleveringen = new List<Aflevering>();
            var Genres = new List<Genre>();
            var Aflevering_Genres = new List<Aflevering_Genre>();

            for (int index = 1; index <= amount; index++)
            {
                var aflevering = new Aflevering()
                {
                    ID = index,
                    lengthe = 27
                };
                Afleveringen.Add(aflevering);

                var genre = new Genre()
                {
                    ID = index,
                    genre = "Spooky"
                };
                Genres.Add(genre);

                Aflevering_Genres.Add(new Aflevering_Genre()
                {
                    ID = index,
                    afleveringID = index,
                    genreID = index,
                    Aflevering = aflevering,
                    Genre = genre
                });
            }

            connection.Afleveringen.AddRange(Afleveringen);
            connection.Genres.AddRange(Genres);
            connection.Aflevering_Genres.AddRange(Aflevering_Genres);

            connection.SaveChanges();
        }

        public void Select(int amount)
        {
            var slice = connection.Aflevering_Genres.Take(amount);
        }

        public void Update(int amount)
        {
            //This method does not work...
            //It does not recognice anything between connection and Take(amount)
            //I have no clue why, so I'll leave it like this for now

            /*var slices = connection.Afleveringen.Take(amount);

            foreach (var slice in slices)
                slice.lengthe = 24;

            connection.UpdateRange(slices);
            connection.SaveChanges();*/
        }

        public void Delete(int amount)
        {
            //This method does not work...
            //It does not recognice anything between connection and Take(amount)
            //I have no clue why, so I'll leave it like this for now

            /*var slicesAG = connection.Aflevering_Genres.Take(amount);
            var slicesA = connection.Afleveringen.Take(amount);
            var sliceG = connection.Genres.Take(amount);

            connection.RemoveRange(slicesAG);
            connection.RemoveRange(slicesA);
            connection.RemoveRange(sliceG);
            connection.SaveChanges();*/
        }

        public bool IsConnected() => connected;

        public string GetName() => $"EF Core ({connection.Database.ProviderName.Split('.').Last()})";
    }

    class NetflixContext : DbContext
    {
        public DbSet<Abonnement> Abonnementen { get; set; }
        public DbSet<Aflevering> Afleveringen { get; set; }
        public DbSet<Aflevering_Genre> Aflevering_Genres { get; set; }
        public DbSet<Aflevering_Kwaliteit> Aflevering_Kwaliteiten { get; set; }
        public DbSet<BekekenAflevering> BekekenAfleveringen { get; set; }
        public DbSet<BekekenFilm> BekekenFilms { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Film_Genre> Film_Genres { get; set; }
        public DbSet<Film_Kwaliteit> Film_Kwaliteits { get; set; }
        public DbSet<Film_OverigeIndicatie> Film_OverigeIndicaties { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Kwaliteit> Kwaliteiten { get; set; }
        public DbSet<LeeftijdsIndicatie> LeeftijdsIndicaties { get; set; }
        public DbSet<Ondertiteling> Ondertitelingen { get; set; }
        public DbSet<OverigeIndicatie> OverigeIndicaties { get; set; }
        public DbSet<Profiel> Profielen { get; set; }
        public DbSet<Seizoen> Seizoenen { get; set; }
        public DbSet<Seizoen_OverigeIndicatie> Seizoen_OverigeIndicaties { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<TeBekijkenItem> TeBekijkenItems { get; set; }
        public DbSet<VoorkeurGenre> VoorkeurGenres { get; set; }
        
        public string connectionString { get; set; }
        
        public NetflixContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["EFConn"].ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
        }
    }
}
