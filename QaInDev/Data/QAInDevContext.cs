using Microsoft.EntityFrameworkCore;
using QaInDev.Models;

namespace QaInDev.Data.Configs
{
    public class QAInDevContext : DbContext
    {
        public QAInDevContext(DbContextOptions<QAInDevContext> options)
            : base(options)
        {

        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QAInDevContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}