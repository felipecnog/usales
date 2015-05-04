using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uSales.Models.Produto;

namespace uSales.Models.Repository
{
    class CategoriaRepository : IRepository<Categoria>
    {
        private SalesContext db;

        public CategoriaRepository(SalesContext categoriaContexto)
        {
            this.db = categoriaContexto;
        }
        public void Apagar(int? id)
        {
            Categoria categoria = db.Categoria.Find(id);
            db.Categoria.Remove(categoria);
        }

        public Produto.Categoria Detalhes(int? id)
        {
            return db.Categoria.Find(id);
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

        public void Editar(Categoria obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Categoria> Listar()
        {
            return db.Categoria.ToList();
        }

        public void Novo(Categoria obj)
        {
            db.Categoria.Add(obj);
        }

        public void Salvar()
        {
            db.SaveChanges();
        }
    }
}
