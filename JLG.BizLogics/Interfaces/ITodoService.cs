using JLG.Models;
using System;
using System.Collections.Generic;

namespace JLG.BizLogics
{
  public interface ITodoService
  {
    public IEnumerable<Todo> GetList();
    public Todo Get(int id);
    public void Add(Todo task);
    public void Update(Todo task);
    public bool Delete(int id);
  }
}
