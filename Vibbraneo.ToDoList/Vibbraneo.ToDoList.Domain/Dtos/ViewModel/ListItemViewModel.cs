using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Domain.Enums;

namespace Vibbraneo.ToDoList.Domain.Dtos.ViewModel
{
    public class ListItemViewModel
    {
        public Guid Id { get; set; }       
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public StatusEnums Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }        
        public List<ItemViewModel> Items { get; set; }
    }
}
