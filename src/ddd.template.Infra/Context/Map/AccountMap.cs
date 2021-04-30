using ddd.template.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace SiteMercado.Payment.Service.Infra.Map
{
    /// <summary>
    /// Example
    /// </summary>
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}