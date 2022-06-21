using Vibbraneo.ToDoList.Domain.Enums;

namespace Vibbraneo.ToDoList.Domain.Dtos.InputModel
{
    public class UpdateItemInputModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public StatusEnums Status { get; set; }
    }
}
