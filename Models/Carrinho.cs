using System.ComponentModel.DataAnnotations;

namespace BackEndC.Models
{
	public class Carrinho
	{
		[Key]
		public int Id { get; set; }
		public List<ItemCarrinho> Itens { get; set; }
		public double ValorTotal { get; set; }

		public void AdicionarProduto(Produto produto, int quantidade)
		{
			// Lógica para adicionar produto ao carrinho
		}

		public void RemoverProduto(Produto produto)
		{
			// Lógica para remover produto do carrinho
		}

        public double CalcularValorTotal()
        {
            if (Itens == null || Itens.Count == 0)
            {
                return 0.0;
            }

            double total = 0.0;

            foreach (var item in Itens)
            {
                if (item.Produto != null)
                {
                    total += item.Produto.Preco * item.Quantidade;
                }
            }

            return total;
        }

    }

    public class ItemCarrinho
	{
		[Key]
		public int Id { get; set; }
		public Produto Produto { get; set; }
		public int Quantidade { get; set; }
	}

}

