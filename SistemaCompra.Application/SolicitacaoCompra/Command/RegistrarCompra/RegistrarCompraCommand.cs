using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        private IEnumerable<ItemCommand> _Itens = new List<ItemCommand>();
        public string UsuarioSolicitante { get; private set; }
        public string NomeFornecedor { get; private set; }
        public IEnumerable<ItemCommand> Itens { get => _Itens; set => _Itens = value; }
    }
}
