using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatsNinja.Models
{
  public class StatisticEntry
  {
    public int StatisticEntryId { get; set; }
    public int PlayerId { get; set; }
    public int SeasonId { get; set; }
    public int StatisticId { get; set; }
    public double StatisticValue { get; set; }
    public Player Player { get; set; }
    public Season Season { get; set; }
    public Statistic Statistic { get; set; }
  }
}