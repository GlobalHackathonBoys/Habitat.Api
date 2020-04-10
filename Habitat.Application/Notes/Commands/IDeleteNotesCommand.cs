using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Commands.Models;

namespace Habitat.Application.Notes.Commands
{
    public interface IDeleteNotesCommand : IAsyncVoidCommand<DeleteNotesModel>
    {
    }
}