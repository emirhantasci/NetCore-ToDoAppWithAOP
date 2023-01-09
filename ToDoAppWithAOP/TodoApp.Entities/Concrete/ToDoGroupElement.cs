using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Entities;

namespace TodoApp.Entities.Concrete
{
    public class ToDoGroupElement:IEntity
    {
        public int Id { get; set; }
        public int ToDoGroupId { get; set; }
        public int ToDoId { get; set; }
    }
}
