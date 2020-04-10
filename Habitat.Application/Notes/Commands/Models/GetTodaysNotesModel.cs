using System;
using System.Collections.Generic;
using Habitat.Application.Interfaces;

namespace Habitat.Application.Notes.Commands.Models
{
    public class GetTodaysNotesModel : IModelValidator
    {
        /// <summary>
        /// TimeZone e.g. Europe/London
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Id of the User to get notes for
        /// </summary>
        public Guid UserId { get; set; }

        public List<string> Validate()
        {
            var errors = new List<string>();
            var validTimeZone = true;

            try
            {
                TimeZoneInfo.FindSystemTimeZoneById(TimeZone);
            }
            catch (TimeZoneNotFoundException e)
            {
                validTimeZone = false;
            }

            if (!validTimeZone)
            {
                errors.Add("Invalid TimeZone");
            }

            if (UserId == Guid.Empty)
            {
                errors.Add("UserId Cannot be Empty");
            }

            return errors;
        }
    }
}