using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibbraneo.ToDoList.Domain.Dtos.ViewModel
{
    public class LoginViewModel
    {
        public string Token { get; set; }
        public UserViewModel User { get; set; }
    }
}
