using Microsoft.EntityFrameworkCore;
using BoardGamesManagment.Entities;

//using BoardGamesManagment.Migrations;

namespace BoardGamesManagment
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rand = new Random();

            AppDbContext db = new AppDbContext();
            
            Menu(rand, db);

        }

        private static void Menu(Random rand, AppDbContext db)
        {
            Console.WriteLine("Menu:\n1)Seed All Tables\n2) Reset Datbase");
            string userChoose = Console.ReadLine();
            if (userChoose == "1")
            {
                SeedMembers(db);
                SeedGames(db);
                SeedSessions(rand, db);
            }
            else if (userChoose == "2") { ResetingDatabase(db); }
            else { Console.WriteLine("Entered something wrong , try again"); Menu(rand, db); }
        }

        private static void ResetingDatabase(AppDbContext db)
        {
            db.Sessions.RemoveRange(db.Sessions);
            db.Members.RemoveRange(db.Members);
            db.Games.RemoveRange(db.Games);
            db.SaveChanges();

            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Sessions', RESEED, 0);");
            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Members', RESEED, 0);");
            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Games', RESEED, 0);");

            Console.WriteLine("Debug Information: Cleaning is complete");
        }

        private static void SeedSessions(Random rand, AppDbContext db)
        {

            DateTime randomDate = new DateTime(
                                year: rand.Next(2000, 2026),      
                                month: rand.Next(1, 13),              
                                day: rand.Next(1, 31)                
                            );


            var Sessions = new List<Sessions>
            {
                new() {Date = randomDate , DurationMinutes = rand.Next(3000), GameId = 1, MemberId = 1},
                new() {Date = randomDate , DurationMinutes = rand.Next(3000), GameId = 2, MemberId = 2},
                new() {Date = randomDate , DurationMinutes = rand.Next(3000), GameId = 3, MemberId = 3},
                new() {Date = randomDate , DurationMinutes = rand.Next(3000), GameId = 4, MemberId = 4},
                new() {Date = randomDate , DurationMinutes = rand.Next(3000), GameId = 5, MemberId = 5}
            };
            db.AddRange(Sessions);
            db.SaveChanges();
        }

        private static void SeedGames(AppDbContext db)
        {
            var Games = new List<Games> {
                new() { Title = "The Long Dark", Genre = "Survival" },
                new() { Title = "Minecraft", Genre = "Sandbox" },
                new() { Title = "Overwatch", Genre = "Shooter" },
                new() { Title = "Stardew Valley", Genre = "Simulation" },
                new() { Title = "Among Us", Genre = "Social Deduction" }
            };
            db.AddRange(Games);
            db.SaveChanges();
        }

        private static void SeedMembers(AppDbContext db)
        {
            var Members = new List<Members>
            {
                new() { FullName = "Alice Morgan" },
                new() { FullName = "Brian Thompson" },
                new() { FullName = "Catherine Lee" },
                new() { FullName = "Daniel Rivera" },
                new() { FullName = "Emily Zhang" }
            };

            db.AddRange(Members);
            db.SaveChanges();

            
        }
    }
}