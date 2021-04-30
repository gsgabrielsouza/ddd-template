using ddd.template.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ddd.template.Infra.Context.Map
{
    /// <summary>
    /// Example
    /// </summary>
    public class ExampleMap : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
