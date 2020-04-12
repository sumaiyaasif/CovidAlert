using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Covid_Stats.Models;

namespace Covid_Alert.CovidApi
{
    public class StateData : IStateData
    {
        public StateData()
        {
        }

        HttpClient client = new HttpClient();
        IEnumerable<StateStats> stateStats1;
        public async Task<IEnumerable<StateStats>> GetStateStats()
        {
            string stateStats;
            var response = await client.GetAsync("https://covidtracking.com/api/states");
            if (response.IsSuccessStatusCode)
            {
                stateStats = response.Content.ReadAsStringAsync().Result;
                stateStats1 = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<StateStats>>(stateStats);
            }
            return await Task.FromResult(stateStats1);
        }
    }

    public interface IStateData
    {
        public Task<IEnumerable<StateStats>> GetStateStats();
    }
}
