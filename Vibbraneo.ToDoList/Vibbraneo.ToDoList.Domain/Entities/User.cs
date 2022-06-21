namespace Vibbraneo.ToDoList.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string userName, string password)
        {
            Name = name;
            Email = email;
            UserName = userName;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public void Update(string name, string email, string userName)
        {
            Name = name;
            Email = email;
            UserName = userName;
            UpdateAt = DateTime.Now;
        }

        public void ChangePassword(string newPasswordHash)
        {
            Password = newPasswordHash;
            UpdateAt = DateTime.Now;
        }
    }
}
