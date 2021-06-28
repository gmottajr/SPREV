﻿using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class CompraRegistradaEventHandler : INotificationHandler<CompraRegistradaEvent>
    {
        public Task Handle(CompraRegistradaEvent notification, CancellationToken cancellationToken)
        {
            return Task.FromResult(notification);
        }
    }
}
