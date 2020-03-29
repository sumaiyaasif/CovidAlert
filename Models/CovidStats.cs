using System;
namespace Covid_Stats.Models
{
    public class CovidStats
    {
        public int NumberOfInfected { get; set; }
        public int NumberOfDeaths { get; set; }
        public int NumberOfRecovered { get; set; }

        public CovidStats()
        {

        }
    }
}
