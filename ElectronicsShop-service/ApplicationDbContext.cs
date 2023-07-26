using ElectronicsShop_service.IdentityHandler;
using ElectronicsShop_service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ElectronicsShop_service;
public class ApplicationDbContext : DbContext
{


    public DbSet<Category>? Categories { get; set; }
	public DbSet<Cloth>? Clothes { get; set; }
	public DbSet<Bill>? Bills { get; set; }
	public DbSet<Store>? Stors { get; set; }
	public DbSet<User>? Users { get; set; }






	private readonly IConfiguration configuration;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
    {
        this.configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        /*if (!optionsBuilder.IsConfigured)
        {
            string connectionString = configuration.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString);
        }*/
        base.OnConfiguring(optionsBuilder);
    }
/*    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new { Id = Guid.NewGuid(), Name = "electronics" },
            new { Id = Guid.NewGuid(), Name = "jewelery" },
            new { Id = Guid.NewGuid(), Name = "men's clothing" },
            new { Id = Guid.NewGuid(), Name = "women's clothing" }
        );
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }*/

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

    
			 
		

		
		builder.Entity<ApplicationRole>().HasData(
			new ApplicationRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN", userId=1 },
			new ApplicationRole { Id = "2", Name = "User", NormalizedName = "USER", userId = 2 }
		);
		builder.Ignore<IdentityUserLogin<string>>();
		builder.Ignore<IdentityUserToken<string>>();
		builder.Ignore<IdentityUserClaim<string>>();
		builder.Ignore<IdentityRoleClaim<string>>();
	}

	
}