using JLG.Models;
using System.Collections.Generic;
using System.Linq;

namespace JLG.BizLogics
{
  public class TodoService: ITodoService
  {
    private List<Todo> _Todos = new List<Todo>();
    private static int _IdCounter = 1; //index number for todo item

    public TodoService()
    {
      //create a pre-existing todo list
      var t1 = new Todo() { Id = _IdCounter++, IsDone = false, Title = "Task AAA" };
      var t2 = new Todo() { Id = _IdCounter++, IsDone = false, Title = "Task BBB" };
      var t3 = new Todo() { Id = _IdCounter++, IsDone = false, Title = "Task CCC" };

      _Todos.Add(t1);
      _Todos.Add(t2);
      _Todos.Add(t3);
    }

    public IEnumerable<Todo> GetList()
    { 
      return _Todos;
    }

    public Todo Get(int id)
    {
      return _Todos.Single(x => x.Id == id);
    }

    public void Add(Todo task)
    {
      task.Id = _IdCounter++; //fill the Id
      
      _Todos.Add(task);
    }

    public void Update(Todo task)
    {
      _Todos.Where(x=> x.Id == task.Id).ToList().
        ForEach(x=> { x.Title = task.Title; x.IsDone = task.IsDone; }
      );
    
    }

    public bool Delete(int id)
    {
      bool result = false;

      try
      {
        var todo = _Todos.Where(x => x.Id == id).SingleOrDefault();

        result = _Todos.Remove(todo);

      }catch (Exception ex)      
      { 
        
      }

      return result;
    }
  }
}
