using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Entities;

namespace TodoApp.Entities.Concrete
{
    public class ToDo:IEntity
    {
        public int Id { get; set; }
        public string ToDoName { get; set; }
        public string ToDoDescription { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public DateTime LastDatetime { get; set; }
    }
}
