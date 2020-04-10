using System;
using System.Collections.Generic;
using Habitat.Application.Interfaces;
using Habitat.Domain.Users;

namespace Habitat.Application.Notes.Commands.Models
{
    public class DeleteNotesModel : IModelValidator
    {
        public Guid UserId { get; set; }
        public List<Guid> NoteIds { get; set; } = new List<Guid>();
        public List<string> Validate()
        {
            var errors = new List<string>();
            
            if (UserId == Guid.Empty)
            {
                errors.Add($"{nameof(UserId)} emtpy");
            }

            for (var i = 0; i < NoteIds.Count; i++)
            {
                if (NoteIds[i] == Guid.Empty)
                {
                    errors.Add($"{nameof(NoteIds)}[{i}] empty");
                }
            }

            return errors;
        }
    }
}