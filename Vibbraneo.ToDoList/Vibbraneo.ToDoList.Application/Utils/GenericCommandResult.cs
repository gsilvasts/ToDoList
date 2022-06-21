using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibbraneo.ToDoList.Application.Interfaces;

namespace Vibbraneo.ToDoList.Application.Utils
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public GenericCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;            
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public object GetData()
        {
            return Data;
        }

        public string GetMessage()
        {
            return Message;
        }

        public void SetData(object data)
        {
            Data = data;
        }

        bool ICommandResult.Success()
        {
            return Success;
        }
    }
}
