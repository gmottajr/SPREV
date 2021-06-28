using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SolctCompAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository _SolicitacaoCompraRepository;
        private readonly IProdutoRepository _ProdutoRepository;

        public RegistrarCompraCommandHandler(SolctCompAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository, 
                                             ProdutoAgg.IProdutoRepository produtoRepository,
                                             IUnitOfWork uow, 
                                             IMediator mediator) : base(uow, mediator)
        {
            this._SolicitacaoCompraRepository = solicitacaoCompraRepository;
            this._ProdutoRepository = produtoRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitCompra = new SolctCompAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);
            foreach (var item in request.Itens)
            {
                var gotProduto = _ProdutoRepository.Obter(item.ProdutoId);
                solicitCompra.AdicionarItem(gotProduto, item.Qtde);
            }

            solicitCompra.RegistrarCompra(solicitCompra.Itens);
            _SolicitacaoCompraRepository.RegistrarCompra(solicitCompra);

            Commit();
            PublishEvents(solicitCompra.Events);

            return Task.FromResult(true);
        }
    }
}
