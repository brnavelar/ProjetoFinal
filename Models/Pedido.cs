using System.ComponentModel.DataAnnotations;

namespace BackEndC.Models
{
	public class Pedido
	{
		[Key]
		public int Id { get; set; }
		public DateTime Data { get; set; }
		public int Quantidade { get; set; }
		public double ValorTotal { get; set; }
		public string EnderecoEntrega { get; set; }

		public Cliente Cliente { get; set; }
		public Carrinho Carrinho { get; set; }
		public Entrega Entrega { get; set; }

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            // Verificar se o Carrinho já existe
            if (Carrinho == null)
            {
                Carrinho = new Carrinho();
            }

            // Adicionar o produto ao Carrinho
            Carrinho.AdicionarProduto(produto, quantidade);

            // Atualizar o ValorTotal do Pedido com base no Carrinho
            ValorTotal = Carrinho.CalcularValorTotal();
        }


        public void RemoverProduto(Produto produto)
        {
            // Verificar se o Carrinho existe
            if (Carrinho != null)
            {
                // Chamar o método RemoverProduto no Carrinho
                Carrinho.RemoverProduto(produto);

                // Atualizar o ValorTotal do Pedido com base no Carrinho
                ValorTotal = Carrinho.CalcularValorTotal();
            }
        }


        public double CalcularValorTotal()
        {
            if (Carrinho != null)
            {
                // Chamar o método CalcularValorTotal no Carrinho
                return Carrinho.CalcularValorTotal();
            }

            // Se o Carrinho não existe, retornar 0
            return 0.0;
        }

    }

}
