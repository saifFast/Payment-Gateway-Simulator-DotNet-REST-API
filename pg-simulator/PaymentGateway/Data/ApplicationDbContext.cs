using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models;

namespace PaymentGateway.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<PaymentTransaction> Payments { get; set; }
        public DbSet<RefundTransaction> Refunds { get; set; }
    }
}
