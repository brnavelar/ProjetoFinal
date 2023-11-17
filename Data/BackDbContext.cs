using BackEndC.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndC.Data
{
    public class BackDbContext : DbContext
    {
        public BackDbContext(DbContextOptions<BackDbContext> options) : base(options) 
        {

        }
        public DbSet<Carrinho> Carrinho { get; set; }
		public DbSet<Cliente> Cliente { get; set; }
		public DbSet<Entrega> Entrega { get; set; }
		public DbSet<Pedido> Pedido { get; set; }
		public DbSet<Produto> Produto { get; set; }
		public DbSet<Vendedor> Vendedor { get; set; }

	}
}
