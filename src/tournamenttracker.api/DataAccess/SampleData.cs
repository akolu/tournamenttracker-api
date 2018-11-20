using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;
using TournamentWebApp.Models;

namespace TournamentWebApp.DataAccess
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<DataContext>();
            if (context.Database.GetDbConnection().DataSource != null && !context.Tournaments.Any())
            {
                context.Tournaments.AddRange(
                    new Tournament
                    {
                        Name = "Test tournament 1",
                        Rounds = new List<Round>()
                    },
                    new Tournament
                    {
                        Name = "Test tournament 2",
                        Rounds = new List<Round>()
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
