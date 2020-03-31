using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Models;

namespace RazorPagesContacts.Data
{
    public class CustomerInfoDbContext : DbContext
    {
        public CustomerInfoDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<CustomerInfo> CustomerInfo { get; set; }
    }
}