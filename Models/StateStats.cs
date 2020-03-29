using System;
namespace Covid_Stats.Models
{
    public class StateStats
    {
        public StateStats()
        {
        }
        public string provincestate { get; set; }
        public string countryregion { get; set; }
        public DateTime lastupdate { get; set; }
        public Location location { get; set; }
        public CountryCode countrycode { get; set; }
        public int confirmed { get; set; }
        public int deaths { get; set; }
        public int recovered { get; set; }
    }
}
