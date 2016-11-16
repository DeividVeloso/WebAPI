using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Mappings
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            ToTable("Authors");

            HasKey(a => a.Id);
            Property(a => a.FirstName).HasMaxLength(60).IsRequired();
            Property(a => a.LastName).HasMaxLength(60).IsRequired();
        
        }


    }
}
