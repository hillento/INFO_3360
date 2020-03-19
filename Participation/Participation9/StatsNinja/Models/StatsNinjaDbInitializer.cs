using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StatsNinja.Models
{
  public class StatsNinjaDbInitializer : DropCreateDatabaseAlways<StatsNinjaDb>
  {
    protected override void Seed(StatsNinjaDb context)
    {
      context.Seasons.Add(new Season { SeasonId = 1, SeasonYears = "1962-1963" });
      context.Seasons.Add(new Season { SeasonId = 2, SeasonYears = "1987-1988" });
      context.Seasons.Add(new Season { SeasonId = 3, SeasonYears = "2008-2009" });
      context.Seasons.Add(new Season { SeasonId = 4, SeasonYears = "2015-2016" });
      context.Seasons.Add(new Season { SeasonId = 5, SeasonYears = "2014-2015" });
      context.Players.Add(new Player { PlayerId = 1, PlayerName = "Wilt Chamberlain", PreProfessionalTeam = "University of Kansas" });
      context.Players.Add(new Player { PlayerId = 2, PlayerName = "Michael Jordan", PreProfessionalTeam = "University of North Carolina" });
      context.Players.Add(new Player { PlayerId = 3, PlayerName = "LeBron James", PreProfessionalTeam = "Saint Vincent-Saint Mary High School" });
      context.Players.Add(new Player { PlayerId = 4, PlayerName = "Stephen Curry", PreProfessionalTeam = "Davidson College" });
      context.Players.Add(new Player { PlayerId = 5, PlayerName = "Anthony Davis", PreProfessionalTeam = "University of Kentucky" });
      context.Statistics.Add(new Statistic { StatisticId = 1, StatisticName = "Player Efficiency Rating (PER)" });
      context.StatisticEntries.Add(new StatisticEntry { StatisticEntryId = 1, PlayerId = 1, SeasonId = 1, StatisticId = 1, StatisticValue = 31.82 });
      context.StatisticEntries.Add(new StatisticEntry { StatisticEntryId = 2, PlayerId = 2, SeasonId = 2, StatisticId = 1, StatisticValue = 31.71 });
      context.StatisticEntries.Add(new StatisticEntry { StatisticEntryId = 3, PlayerId = 3, SeasonId = 3, StatisticId = 1, StatisticValue = 31.67 });
      context.StatisticEntries.Add(new StatisticEntry { StatisticEntryId = 4, PlayerId = 4, SeasonId = 4, StatisticId = 1, StatisticValue = 31.46 });
      context.StatisticEntries.Add(new StatisticEntry { StatisticEntryId = 5, PlayerId = 5, SeasonId = 5, StatisticId = 1, StatisticValue = 30.81 });
    }

  }
}