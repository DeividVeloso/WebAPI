using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Contracts
{
    //Criado para aceitar qualquer objeto para fazer o CRUD de todos
    //Pois senão eu teria que repetir esse código de assinaturas de metodos para cada objeto Domain
    //Se eu passar qualquer objeto ele gera com esses métodos, por isso o uso do generics <T>
    public interface IRepository<T> : IDisposable
    {
        List<T> Get(int skip = 0, int take = 25);
        T Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
