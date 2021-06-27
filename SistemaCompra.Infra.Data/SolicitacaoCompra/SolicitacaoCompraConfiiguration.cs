using Microsoft.EntityFrameworkCore;
using SolicitCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiiguration : IEntityTypeConfiguration<SolicitCompraAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitCompraAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");

            builder.HasKey(a => a.Id);

            builder.OwnsOne(p => p.NomeFornecedor, nomeFornecedor =>
            {
                nomeFornecedor.Property(p => p.Nome).HasColumnName("NomeFornecedor").HasMaxLength(300);
            });

            builder.OwnsOne(x => x.UsuarioSolicitante, solicitante =>
            {
                solicitante.Property(m => m.Nome).HasColumnName("UsuarioSolicitante").HasMaxLength(200);
            });
        }
    }
}
