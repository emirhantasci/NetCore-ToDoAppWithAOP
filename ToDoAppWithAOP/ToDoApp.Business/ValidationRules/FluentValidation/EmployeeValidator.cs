using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities.Concrete;

namespace ToDoApp.Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator: AbstractValidator<ToDo>
    {
        public EmployeeValidator()
        {
            
        }
    }
}
