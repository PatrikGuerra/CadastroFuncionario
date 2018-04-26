using System.Collections.Generic;
using System.Linq;
using CadastroFuncionario.Shared.Commands;

namespace CadastroFuncionario.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult() { }

        public CommandResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
            this.Erros = new List<Flunt.Notifications.Notification>();
        }

        public CommandResult(Shared.Entities.Entity entidade, bool success, string message) 
            : this(success, message)
        {
            this.Erros = entidade.Notifications.ToList();
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Flunt.Notifications.Notification> Erros { get; set; }
    }
}
