using System;
using System.Collections.Generic;
using System.Text;
using SolicCompAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : SolicCompAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext _Context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this._Context = context;
        }
        public void RegistrarCompra(SolicCompAgg.SolicitacaoCompra solicitacaoCompra)
        {
            _Context.Set<SolicCompAgg.SolicitacaoCompra>().Add(solicitacaoCompra);
        }
    }
}
