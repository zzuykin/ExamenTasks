


using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var context = new MyDbContext();
var testTable = new MyTable() {Name = "Nikita" };

context.MyTables.Add(testTable);
context.SaveChanges();

public class MyTable
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
}

public class MyDbContext : DbContext
{
    public DbSet<MyTable> MyTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDb;Trusted_Connection=True;");
    }
}

