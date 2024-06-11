using Microsoft.AspNetCore.Mvc;
namespace Task18.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private static List<Student> _students = new List<Student>
    {
        new Student { Id = 1, Name = "John Doe", Email = "john@example.com" },
        new Student { Id = 2, Name = "Jane Doe", Email = "jane@example.com" }
    };

    [HttpGet("{id}")]
    public ActionResult<Student> Get(int id)
    {
        var student = _students.FirstOrDefault(x => x.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }


    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        return Ok(_students);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Student student)
    {
        _students.Add(student);
        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Student student)
    {
        var existingStudent = _students.FirstOrDefault(s => s.Id == id);
        if (existingStudent == null)
        {
            return NotFound();
        }
        existingStudent.Name = student.Name;
        existingStudent.Email = student.Email;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        _students.Remove(student);
        return NoContent();
    }
}