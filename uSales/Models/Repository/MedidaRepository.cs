using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uSales.Models.Produto;

namespace uSales.Models.Repository
{
    class MedidaRepository : IRepository<Medida>
    {
        private SalesContext db;

        public MedidaRepository(SalesContext medidaContexto)
        {
            this.db = medidaContexto;
        }
        public void Apagar(int? id)
        {
            Medida medida = db.Medida.Find(id);
            db.Categoria.Remove(medida);
        }

        public Produto.Medida Detalhes(int? id)
        {
            return db.Medida.Find(id);
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

        public void Editar(Medida obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Medida> Listar()
        {
            return db.Medida.ToList();
        }

        public void Novo(Medida obj)
        {
            db.Medida.Add(obj);
        }

        public void Salvar()
        {
            db.SaveChanges();
        }
    }
}
