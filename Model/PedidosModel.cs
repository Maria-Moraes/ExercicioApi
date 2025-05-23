using Exercicio01.Enums;

namespace Exercicio01.Model
{
    public class PedidosModel
    {
        public int Id { get; set; }
        public int usuarioId { get; set; }
        public string EnderecoEntrega { get; set; }
        public StatusPedidos Status { get; set; }
        public string MetodoPagamento { get; set; }
    }
}
