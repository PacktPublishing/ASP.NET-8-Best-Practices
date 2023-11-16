using EntityFrameworkThemePark.DataContext.Models;
using EntityFrameworkThemePark.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace EntityFrameworkThemePark.DataContext.Configuration;

public class AttractionConfiguration : IEntityTypeConfiguration<Attraction>
{
    public void Configure(EntityTypeBuilder<Attraction> builder)
    {
        builder.ToTable("Attraction");

        builder
            .HasOne(d => d.Location)
            .WithMany(p => p.Attractions)
            .OnDelete(DeleteBehavior.ClientSetNull);

        var records = JsonConvert.DeserializeObject<Attraction[]>(
            SeedResource.AttractionRecords);
        if (records != null)
        {
            builder.HasData(records);
        }
    }
}