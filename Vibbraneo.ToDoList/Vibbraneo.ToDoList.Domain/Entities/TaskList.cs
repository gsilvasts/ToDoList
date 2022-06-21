using Vibbraneo.ToDoList.Domain.Enums;

namespace Vibbraneo.ToDoList.Domain.Entities
{
    public class TaskList : BaseEntity
    {
        public TaskList(Guid userId, string title, string description, StatusEnums status)
        {            
            UserId = userId;
            Title = title;
            Description = description;
            Status = status;
        }

        public User User { get; private set; }
        public Guid UserId { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public StatusEnums Status { get; private set; }
        public ICollection<Item>? Items { get; set; }        

        public void Update(string title, string description, StatusEnums status)
        {
            Title = title;
            Description = description;
            Status = status;
            UpdateAt = DateTime.Now;
        }

        public void UpdateStatus(StatusEnums status)
        {
            Status = status;
            UpdateAt = DateTime.Now;
        }
    }
}
