namespace QaInDev.Models
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
    }
}