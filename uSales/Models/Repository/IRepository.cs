using System;
using System.Collections.Generic;
using System.Collections;
using uSales.Models;

namespace uSales.Models.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> Listar();
        T Detalhes(int? id);
        void Novo(T obj);
        void Apagar(int? id);
        void Editar(T obj);
        void Salvar();

    }
}
