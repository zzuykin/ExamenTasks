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
            new MyObject { Id = 1, Name = "Объект1", Description = "Описание1" },
            new MyObject { Id = 2, Name = "Объект2", Description = "Описание2" },
            new MyObject { Id = 3, Name = "Объект3", Description = "Описание3" }
        };
    }
}

public class MyObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
