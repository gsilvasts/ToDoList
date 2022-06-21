using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibbraneo.ToDoList.Application.Interfaces
{
    public interface ICommandResult
    {
        bool Success();
        object GetData();
        void SetData(object data);
        string GetMessage();
    }
}
