using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Domain.Enums;

namespace Vibbraneo.ToDoList.Domain.Dtos.InputModel
{
    public class CreateListInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusEnums Status { get; set; }
    }
}
