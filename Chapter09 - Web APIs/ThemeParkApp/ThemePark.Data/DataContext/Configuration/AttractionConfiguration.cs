
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ThemePark.Data.DataContext.Models;
using ThemePark.Data.SeedData;

namespace ThemePark.Data.DataContext.Configuration;

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