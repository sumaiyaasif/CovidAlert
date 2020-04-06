using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesContacts.Data;
using RazorPagesContacts.Models;

namespace Covid_Alert.Pages
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesContacts.Data.CustomerInfoDbContext _context;

        public CreateModel(RazorPagesContacts.Data.CustomerInfoDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            string[] list = { "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC",
                            "FM", "FL", "GA", "GU", "HI", "ID", "IL", "IN", "IA", "KS",
                            "KY", "LA", "ME", "MH", "MD", "MA", "MI", "MN", "MS", "MO",
                            "MT", "NE", "NV", "NH", "NM", "NY", "NC", "ND", "MP", "OH",
                            "OK", "OR", "PW", "PA", "PR", "RI", "SC", "SD", "TN", "TX",
                            "UT", "VT", "VI", "VA", "WA", "WV", "WI", "WY"};
            stateList = new SelectList(list);
            return Page();
        }

        [BindProperty]
        public CustomerInfo CustomerInfo { get; set; }
        public SelectList stateList { get; set; }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomerInfo.Add(CustomerInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
