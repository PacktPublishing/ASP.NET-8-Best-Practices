using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ThemePark.DataContext.Models;
using ThemePark.SeedData;

namespace ThemePark.DataContext.Configuration;

public class AttractionConfiguration : IEntityTypeConfiguration<Attraction>
{
    public void Configure(EntityTypeBuilder<Attraction> builder)
    {
        builder.HasOne<Location>(d => d.Location)
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