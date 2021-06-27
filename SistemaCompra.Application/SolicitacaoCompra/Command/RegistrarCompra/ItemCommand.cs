using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class ItemCommand
    {
        public Guid ProdutoId { get; set; }
        public int Qtde { get; set; }
    }
}
