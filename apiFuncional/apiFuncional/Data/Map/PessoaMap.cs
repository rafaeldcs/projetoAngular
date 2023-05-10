using apiTestes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace apiTestes.Data.Map
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {

        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(300);



        }
    }
}
