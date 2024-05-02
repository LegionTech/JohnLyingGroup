using Assert = Xunit.Assert;
using JLG.BizLogics;
using JLG.Models;

namespace JLG.Tests
{
  public class UnitTest_TodoService
  {
    private ITodoService _todoService;

    public UnitTest_TodoService()
    {
      _todoService = new TodoService();     
    }

    //Test Service Get() function that has an exist item
    [Fact]
    public void Test1_Get_Exist()
    {
      var todos = _todoService.GetList();

      //var usedId = todos.Select(x => x.Id).Last(); //the last used Id

      var todo1 = todos.First();

      var todo2 = _todoService.Get(todo1.Id);

      Assert.Equal(todo1.Id, todo2.Id);

      Assert.Equal(todo1.Title, todo2.Title);
    }

    //Test Service Get() function that has NO exist item
    [Fact]
    public void Test2_Get_NoExist()
    {
      var todos = _todoService.GetList();

      var lastId = todos.Select(x => x.Id).Max();

      var id = lastId + 3; //an Id that doesn't exist

      var todo = _todoService.Get(id);

      Assert.Null(todo);
    }

    //Test Service Add() function
    [Fact]
    public void Test3_Add()
    {
      var todos1 = _todoService.GetList();

      var usedId = todos1.Select(x => x.Id).Last(); //the last used Id

      var size1 = todos1.Count();

      string title = "Task DDD";

      var t1 = new Todo() { Title = title };

      _todoService.Add(t1);

      //get the updated list
      var todos2 = _todoService.GetList();
      var size2 = todos2.Count();
      var t2 = todos2.Last();      

      Assert.Equal(size1 + 1, size2);
      Assert.Equal(usedId + 1, t2.Id);
      Assert.Equal(title, t2.Title);
    }

    //Test Service Delete() function
    [Fact]
    public void Test4_Delete()
    {
      var todos1 = _todoService.GetList();

      var size1 = todos1.Count();

      var firstId = todos1.Select(x => x.Id).Min(); //Id of the first todo

      _todoService.Delete(firstId);

      var todos2 = _todoService.GetList();

      var size2 = todos2.Count();

      Assert.Equal(size1 - 1, size2);
    }

  }
}