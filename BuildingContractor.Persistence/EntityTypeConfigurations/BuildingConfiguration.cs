using Microsoft.EntityFrameworkCore;
using BuildingContractor.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingContractor.Persistence.EntityTypeConfigurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.contractorID).IsRequired();
            builder.Property(note => note.contractorID).IsRequired();
            builder.Property(note => note.conlusionDate).IsRequired();
            builder.Property(note => note.deliveryDate).IsRequired();
            builder.Property(note => note.comissioningDate).IsRequired();
        }
    }
}
