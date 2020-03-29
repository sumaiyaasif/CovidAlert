using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Data;
using RazorPagesContacts.Models;

namespace Covid_Alert.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesContacts.Data.CustomerInfoDbContext _context;

        public IndexModel(RazorPagesContacts.Data.CustomerInfoDbContext context)
        {
            _context = context;
        }

        public IList<CustomerInfo> CustomerInfo { get;set; }

        public async Task OnGetAsync()
        {
            CustomerInfo = await _context.Customers.ToListAsync();
        }
    }
}
