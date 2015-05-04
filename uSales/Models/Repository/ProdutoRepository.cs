using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uSales.Models.Produto;

namespace uSales.Models.Repository
{
    class ProdutoRepository : IRepository<Produto.Produto>
    {
        private SalesContext db;
        public ProdutoRepository(SalesContext produtoContexto)
        {
            this.db = produtoContexto;
        }
        public void Apagar(int? id)
        {
            Produto.Produto produto = db.Produto.Find(id);
            db.Produto.Remove(produto);
        }

        public Produto.Produto Detalhes(int? id)
        {
            return db.Produto.Find(id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool v)
        {
            if (!this.disposed) if (v) db.Dispose();
            this.disposed = true;
        }

        public void Editar(Produto.Produto obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Produto.Produto> Listar()
        {
            return db.Produto.ToList();
        }

        public void Novo(Produto.Produto obj)
        {
            db.Produto.Add(obj);
        }

        public void Salvar()
        {
            db.SaveChanges();
        }
    }
}
