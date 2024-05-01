using Microsoft.AspNetCore.Mvc;
using JLG.BizLogics;
using JLG.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JLG.API.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
      _todoService = todoService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Todo>> GetAll()
    {
      return Ok(_todoService.GetList());
    }

    [HttpGet("{id}")]
    public ActionResult<Todo> Get(int id)
    {
      var todo = _todoService.Get(id);

      if(todo == null)
      {
        return NotFound();
      }

      return Ok(todo);
    }

    [HttpPut]
    public ActionResult Add([FromBody] Todo item)
    {
      var updateItem = _todoService.Add(item);

      if (updateItem == null)
      {
        return NotFound();
      }

      return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      var result = _todoService.Delete(id);

      return result ? Ok() : NotFound();
    }

    [HttpPost("{id}")]
    public ActionResult Update([FromRoute] int id, [FromBody] Todo item)
    {
      if (id != item.Id)
        return BadRequest();

      _todoService.Update(item);

      return Ok();
    }

  }
}
