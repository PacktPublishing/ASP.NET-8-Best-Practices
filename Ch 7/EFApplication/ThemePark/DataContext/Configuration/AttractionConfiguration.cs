using EFApplication.DataContext.Models;
using EFApplication.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace EFApplication.DataContext.Configuration;

public class AttractionConfiguration : IEntityTypeConfiguration<Attraction>
{
    public void Configure(EntityTypeBuilder<Attraction> builder)
    {
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