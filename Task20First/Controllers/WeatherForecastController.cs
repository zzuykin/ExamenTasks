using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class FirstController : Controller
{
    [HttpGet]
    public IEnumerable<MyObject> Get()
    {
        return new List<MyObject>
        {
            new MyObject { Id = 1, Name = "������1", Description = "��������1" },
            new MyObject { Id = 2, Name = "������2", Description = "��������2" },
            new MyObject { Id = 3, Name = "������3", Description = "��������3" }
        };
    }
}

public class MyObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
