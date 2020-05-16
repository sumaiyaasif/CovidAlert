using System;
namespace Covid_Stats.Models
{
    public class StateStats
    {
        public string State { get; set; }
        public long Positive { get; set; }
        public long? PositiveScore { get; set; }
        public long? NegativeScore { get; set; }
        public long? NegativeRegularScore { get; set; }
        public long? CommercialScore { get; set; }
        public string? Grade { get; set; }
        public long? Score { get; set; }
        public string Notes { get; set; }
        public string DataQualityGrade { get; set; }
        public long? Negative { get; set; }
        public long? Pending { get; set; }
        public long? HospitalizedCurrently { get; set; }
        public long? HospitalizedCumulative { get; set; }
        public long? InIcuCurrently { get; set; }
        public long? InIcuCumulative { get; set; }
        public long? OnVentilatorCurrently { get; set; }
        public long? OnVentilatorCumulative { get; set; }
        public long? Recovered { get; set; }
        public string LastUpdateEt { get; set; }
        public string CheckTimeEt { get; set; }
        public long Death { get; set; }
        public long? Hospitalized { get; set; }
        public long Total { get; set; }
        public long TotalTestResults { get; set; }
        public long PosNeg { get; set; }
        public string Fips { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset DateChecked { get; set; }
        public string Hash { get; set; }
    }

}
