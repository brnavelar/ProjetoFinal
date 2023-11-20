using System.ComponentModel.DataAnnotations;

namespace BackEndC.Models
{
	public class Vendedor
	{
		[Key]
		public int Id { get; set; }
		public string Nome { get; set; }
		public string CNPJ { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public string Email { get; set; }
        public string Senha { get; set; }
    }

}
