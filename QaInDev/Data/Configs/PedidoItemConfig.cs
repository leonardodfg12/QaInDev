using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QaInDev.Models;

namespace QaInDev.Data.Configs
{
    public class PedidoItemConfig : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable(nameof(PedidoItem));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PedidoId)
            .IsRequired();
        }
    }
}