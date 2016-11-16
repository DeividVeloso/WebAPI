using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Contracts
{
    //IBook herda de IRepo enviando o Book, que significa que vai gerar os métodos CRUD para o Book
    //E ainda ele terá as suas próprias assinaturas de métodos
    public interface IBookRepository : IRepository<Book>
    {
        List<Book> GetWithAuthors(int skip = 0, int take = 25);
        Book GetWithAuthors(int id);
    }
}
