using Habitat.Domain.Notes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Habitat.DataAccess.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("note");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.NoteText).HasColumnName("note_text");
            builder.Property(p => p.EventDateTime).HasColumnName("event_date_time");
            builder.Property(p => p.UserId).HasColumnName("user_id");
        }
    }
}