
namespace Exercicio01.Model
{
    public class ProdutosModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }

        public static implicit operator ProdutosModel(CategoriasModel v)
        {
            throw new NotImplementedException();
        }
    }
}
