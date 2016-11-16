using BookStore.Data.Mappings;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.DataContexts
{
    public class BookStoreDataContext : DbContext
    {
        public BookStoreDataContext() 
            : base("BookStoreConnectionString")
        {
            //Carregamento Tardio, so o que eu quiser
            Configuration.LazyLoadingEnabled = false;
            //Normalmente o entityframework, guarda dados no contexto de alteração de objeto antigo, 
            //(Qual era o nome antes de mudar) referente ao objeto que está sendo manipulado etc..Causa perda de performance
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        //Antes de gerar o banco ele verifica meu mapeamento
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new AuthorMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
