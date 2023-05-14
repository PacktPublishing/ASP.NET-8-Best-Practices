using EFApplication.DataContext.Models;
using EFApplication.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace EFApplication.DataContext.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedNever();

        var records = JsonConvert.DeserializeObject<Location[]>(
            SeedResource.LocationRecords);
        if (records != null)
        {
            builder.HasData(records);
        }
    }
}