using Habitat.Domain.Todos;
using Habitat.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Habitat.DataAccess.Configurations
{
    public class TodoConfigruation : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("todo");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Done).HasColumnName("done");
            builder.Property(p => p.NoteText).HasColumnName("note_text");
            builder.Property(p => p.UserId).HasColumnName("user_id");
            builder.Property(p => p.EventDateTime).HasColumnName("event_date_time");

            builder.HasOne(todo => todo.User).WithMany(todo => todo.Todos);
        }
    }
}