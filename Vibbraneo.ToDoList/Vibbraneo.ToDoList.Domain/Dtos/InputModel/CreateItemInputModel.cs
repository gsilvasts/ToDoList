using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Domain.Enums;

namespace Vibbraneo.ToDoList.Domain.Dtos.InputModel
{
    public class CreateItemInputModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public Guid ListId { get; set; }
        public Guid? ItemId { get; set; } = null;
        public StatusEnums Status { get; set; }
    }
}
