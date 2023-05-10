using apiTestes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiTestes.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {  
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TipoContato).IsRequired().HasMaxLength(200);


          
        }
    }
}
