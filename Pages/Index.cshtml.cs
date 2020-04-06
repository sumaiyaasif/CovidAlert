using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid_Alert.CovidApi;
using Covid_Stats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Data;
using RazorPagesContacts.Models;

namespace Covid_Alert.Pages
{
    public class IndexModel : PageModel
    {

        public IndexModel()
        {

        }

        public IEnumerable<StateStats> statesInfo { get; set; }
        StateData stateData = new StateData();
        public async Task OnGetAsync()
        {
            statesInfo = stateData.GetStateStats().Result;
            await Task.CompletedTask;
        }


    }
}
