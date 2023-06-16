using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QaInDev.Models;

namespace QaInDev.Data.Configs
{
    public class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable(nameof(Pedido));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClientId)
            .IsRequired();
            builder.HasMany(x => x.PedidoItens);
        }
    }
}