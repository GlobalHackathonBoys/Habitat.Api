using System;
using System.Collections.Generic;
using Habitat.Application.Interfaces;
using Habitat.Application.Notes.Commands.Models;

namespace Habitat.Application.Notes.Commands
{
    public interface IAddNotesCommand : IAsyncCommand<AddNotesModel, AddNotesResponse>
    {
    }
}