using System.ComponentModel.DataAnnotations;

namespace BackEndC.Models
{
	public class Entrega
	{
		[Key]
		public int Id { get; set; }
		public string Status { get; set; }
		public double Custo { get; set; }

		public void AtualizarStatus(string novoStatus)
		{
			// Lógica para atualizar o status da entrega
		}

		public double CalcularCusto()
		{
			// Lógica para calcular o custo da entrega
			return 0;
		}
	}

}
