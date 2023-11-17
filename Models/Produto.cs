using System.ComponentModel.DataAnnotations;

namespace BackEndC.Models
{
	public class Produto
	{
		[Key] 
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public double Preco { get; set; }
		public string Categoria { get; set; }
		public int Quantidade { get; set; }
	}

}
