using GGStore.Domain.GameDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GGStore.Database.EntityTypeConfigurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(group => group.Id);
        builder.HasIndex(group => group.Id).IsUnique();
        builder.Property(group => group.Title).HasMaxLength(250);
    }
}