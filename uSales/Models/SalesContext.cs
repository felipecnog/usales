using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace uSales.Models
{
    class SalesContext : DbContext
    {
        public SalesContext() : base("usales")
        {

        }

        public DbSet<Produto.Produto> Produto { get; set; }
        public DbSet<Produto.Categoria> Categoria { get; set; }
        public DbSet<Produto.Medida> Medida { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
