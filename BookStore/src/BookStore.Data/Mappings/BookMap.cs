using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Mappings
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Books");
            HasKey(b => b.Id);
            Property(b => b.Title).HasMaxLength(255).IsRequired();
            Property(b => b.Price).IsRequired().HasColumnType("money");
            Property(b => b.ReleaseDate).IsRequired();
            HasMany(b => b.Authors).WithMany(b => b.Books);

        }
    }
}
