

using Microsoft.AspNetCore.Mvc;

namespace Task19.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserManager _userManger;

    private static List<User> _users = new List<User>
    {
        new User{Id = 1, Name = "John Doe"}, new User{Id = 2, Name = "Nikita"}
    };
    public UserController(IUserManager userManger)
    {
        _userManger = userManger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAll()
    {
        return Ok(_users);
    }

    [HttpPost]
    public ActionResult Post([FromBody] User user)
    {
        var item = _userManger.ChangeSome(user);
        _users.Add(item);
        return Ok();
    }
}
