using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using TPAY.Models;

namespace TPAY.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions) { }
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.UseSerialColumns();
        modelBuilder.Entity<UserData>().Property(x => x.Id);
        modelBuilder.Entity<Student>().Property(x => x.Id);
        modelBuilder.Entity<Product>().Property(x => x.Id);
        modelBuilder.Entity<Payment>().Property(x => x.Id);
            
            
    }
        

    public DbSet<UserData> UserData { get; set; }
    public DbSet<Payment> Payment{ get; set; }
    public DbSet<Product> Product{ get; set; }
    public DbSet<Student> Student{ get; set; }

}