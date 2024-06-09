
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

var timer = new Stopwatch();
var context = new MyDbContext();
//for(int  i = 0; i < 1000000; i++)
//{
//    var item = new MyTable() { Name = $"num{i}" };
//    context.MyTables.Add(item);
//    context.SaveChanges();
//}

var rand = new Random();
Console.WriteLine("Поиск по ключу");
timer.Start();
for(int i = 0;i < 1000; i++)
{
    int id = rand.Next(20000);
    var item = context.MyTables.FirstOrDefault(x => x.Id == id);
    Console.WriteLine($"Запись с ключём {item.Id} найдена");
}
timer.Stop();

var timer2 = new Stopwatch();
Console.WriteLine("Поиск по имени:");
timer2.Start();
for(int i = 0; i < 1000; i++)
{
    string name = $"num{rand.Next(20000)}";
    var item = context.MyTables.FirstOrDefault(x => x.Name == name);
    Console.WriteLine($"Запись с именем {item.Name} найдена");
}

Console.WriteLine($"Время поиска по ключу:{timer.Elapsed.TotalSeconds} сек");
Console.WriteLine($"Время поиска по имени:{timer2.Elapsed.TotalSeconds} сек");

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
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDbTask13;Trusted_Connection=True;");
    }
}

