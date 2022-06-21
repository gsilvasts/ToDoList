using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibbraneo.ToDoList.Application.Utils
{
    public class BaseHandler : Notifiable<Notification>
    {
        public GenericCommandResult SuccessResult()
        {
            return new GenericCommandResult(true, "Operação realizada com sucesso", null);
        }

        public GenericCommandResult SuccessResult(object data)
        {
            return new GenericCommandResult(true, "Operacação realizada com sucesso", data);
        }

        public GenericCommandResult SuccessResult(string message, object data)
        {
            return new GenericCommandResult(true, message, data);
        }
        public GenericCommandResult NotFoundResult(object data)
        {
            return new GenericCommandResult(true, "Dados não encontrados", data);
        }

        public GenericCommandResult NotFoundResult()
        {
            return new GenericCommandResult(true, "Dados não encontrados", null);
        }

        public GenericCommandResult ErrorResult(object data)
        {
            return new GenericCommandResult(false, "Erro ao realizar a operação", data);
        }

        public GenericCommandResult ErrorResult(string mensagem, object data)
        {
            return new GenericCommandResult(false, mensagem, data);
        }

        public GenericCommandResult ErrorResult()
        {
            return new GenericCommandResult(false, "Erro ao realizar a operação", null);
        }
    }
}
