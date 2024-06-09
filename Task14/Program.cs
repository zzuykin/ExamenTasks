using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using (MyDbContext context = new MyDbContext())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    Company apple = new Company() { Name = "Apple" };
    Company samsung = new Company() { Name = "Sumsung" };

    context.Companies.AddRange(apple, samsung);
    context.SaveChanges();

    User tom = new User { Name = "Tom", Company = apple };
    User bob = new User { Name = "Bob", Company = apple };
    User alice = new User { Name = "Alice", Company = samsung };
    User kate = new User { Name = "Kate", Company = samsung };

    context.Users.AddRange(tom, bob, alice, kate);
    context.SaveChanges();
}


using (MyDbContext context = new MyDbContext())
{
    var users = context.Users.ToList();
    foreach(var user in users)
    {
        Console.WriteLine($"User name is {user.Name} - company is {user.Company?.Name}");
    }
}

using (MyDbContext context = new MyDbContext())
{
    var companies = context.Companies.ToList();
    foreach(var company in companies)
    {
        foreach(var user in company.Users)
        {
            Console.WriteLine($"Company is {company.Name} and User's name is {user.Name}");
        }
    }
}


public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public int CompanyID { get; set; }
    public virtual Company Company { get; set; }
}

public class Company
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual List<User> Users { get; set; }
}

public class MyDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDbTask14;Trusted_Connection=True;");
    }
}