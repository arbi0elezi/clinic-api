using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicApi.Data_Models;
using Type = ClinicApi.Data_Models.Type;

namespace ClinicApi.Data_Seeders
{
    public class DataSeeder
    {
        private static readonly Random _random = new Random();
        private static string GenerateEmail()
        {
            var random = new Random();

            return
                $"{GenerateNames(random.Next(10, 25))}@{GenerateNames(_random.Next(5, 15))}.{GenerateNames(random.Next(3, 6))}";
        }

        private static string GenerateNames(int count = 22)
        {
            var  random = new Random();
            
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, count)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
        public static void SeedData()
        {
            using (var context = new ClinicModelContainer())
            {
                var psychologists = context.Psychologists.ToList();
                var clients = context.Clients.ToList();
                var sessions = context.Sessions.ToList();

                context.Sessions.RemoveRange(sessions);
                context.Clients.RemoveRange(clients);
                context.Psychologists.RemoveRange(psychologists);

                context.SaveChanges();


                var addedPsychologists = new List<Psychologist>();
                var addedClients = new List<Client>();
                var addedSessions = new List<Session>();


                var psychologistCount = _random.Next(20, 60);

                for (var i = 0; i < psychologistCount; i++)
                {
                    

                    var psychologist = new Psychologist
                    {
                        Id = Guid.NewGuid(),
                        Email = GenerateEmail(),
                        Name = GenerateNames(_random.Next(10, 25))
                    };
                    

                    var clientsCount = _random.Next(1, 6);

                    for (var j = 0; j < clientsCount; j++)
                    {
                        var sessionsCount = _random.Next(1, 6);

                        var client = new Client
                        {
                            Id = Guid.NewGuid(),
                            Email = GenerateEmail(),
                            Name = GenerateNames(_random.Next(10, 25)),
                            PsychologistId = psychologist.Id
                        };

                        for (var k = 0; k < sessionsCount; k++)
                        {
                            var coeff = _random.Next(0, 2) % 2 == 0 ? 1 : -1;
                            var diff = _random.Next(1, 25);
                            var session = new Session
                            {
                                Id = Guid.NewGuid(),
                                BookedDate = DateTime.Now.AddDays(coeff * diff).AddHours(coeff * diff),
                                ClientId = client.Id,
                                PsychologistId = psychologist.Id,
                                Type = _random.Next(1, 6) % 2 == 0 ? Type.Audio : Type.Video
                            };

                            addedSessions.Add(session);
                        }

                        addedClients.Add(client);
                    }

                    addedPsychologists.Add(psychologist);
                }


                context.Psychologists.AddRange(addedPsychologists);
                context.Clients.AddRange(addedClients);
                context.Sessions.AddRange(addedSessions);

                context.SaveChanges();
            }
        }
    }
}