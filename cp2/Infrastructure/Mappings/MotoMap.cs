using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cp2.Domain.Entity;

namespace cp2.Infrastructure.Mappings
{
    public class MotoMap : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.ToTable("Motos");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Modelo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.UsuarioId)
                .IsRequired();

            builder.HasOne(m => m.Usuario)
                .WithMany(u => u.Motos)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
