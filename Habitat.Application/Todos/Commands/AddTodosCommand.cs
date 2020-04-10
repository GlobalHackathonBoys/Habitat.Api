using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Habitat.Application.Todos.Commands.Models;
using Habitat.Application.Users;
using Habitat.Domain.Todos;
using Microsoft.Extensions.Logging;

namespace Habitat.Application.Todos.Commands
{
    public class AddTodosCommand : IAddTodosCommand
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AddTodosCommand> _logger;

        public AddTodosCommand(
            ITodoRepository todoRepository, 
            IUserRepository userRepository,
            ILogger<AddTodosCommand> logger)
        {
            _todoRepository = todoRepository;
            _userRepository = userRepository;
            _logger = logger;
        }
        
        public async Task<AddTodosResponseModel> ExecuteAsync(AddTodosRequestModel request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Getting User: {request.UserId}");
            var user = _userRepository.Get(new[] {request.UserId}).FirstOrDefault();
            
            if (user == null)
            {
                _logger.LogWarning($"User: {request.UserId} does not exist");
                return new AddTodosResponseModel { Success = false };
            }

            var todos = request.Todos.Select(todo => new Todo
            {
                Done = todo.Done,
                NoteText = todo.Text,
                EventDateTime = todo.DateTime.ToUniversalTime().DateTime
            }).ToList();

            foreach (var todo in todos)
            {
                user.Todos.Add(todo);
            }

            await _userRepository.SaveChangesAsync(cancellationToken);
            
            return new AddTodosResponseModel
            {
                Success = true,
                UserId = user.Id,
                TodoIds = todos.Select(todo => todo.Id).ToList()
            };
        }
    }
}