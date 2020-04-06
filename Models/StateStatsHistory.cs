using System;
namespace Covid_Stats.Models
{
    public class StateStats
    {
        public string state { get; set; }
        public int? positive { get; set; }
        public int positiveScore { get; set; }
        public int negativeScore { get; set; }
        public int negativeRegularScore { get; set; }
        public int commercialScore { get; set; }
        public string grade { get; set; }
        public int score { get; set; }
        public int negative { get; set; }
        public int? pending { get; set; }
        public int? hospitalizedCurrently { get; set; }
        public int? hospitalizedCumulative { get; set; }
        public int? inIcuCurrently { get; set; }
        public int? inIcuCumulative { get; set; }
        public int? onVentilatorCurrently { get; set; }
        public int? onVentilatorCumulative { get; set; }
        public int? recovered { get; set; }
        public string lastUpdateEt { get; set; }
        public string checkTimeEt { get; set; }
        public int? death { get; set; }
        public int? hospitalized { get; set; }
        public int total { get; set; }
        public int totalTestResults { get; set; }
        public int posNeg { get; set; }
        public string fips { get; set; }
        public DateTime dateModified { get; set; }
        public DateTime dateChecked { get; set; }
        public string notes { get; set; }
        public string hash { get; set; }
    }
}
