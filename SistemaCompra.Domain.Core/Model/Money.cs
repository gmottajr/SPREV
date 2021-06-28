using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.Core.Model
{
    public class Money : ValueObject<Money>
    {
        public decimal Valor { get; private set; }

        public Money()
                : this(0m)
        {
        }

        public Money(decimal value)
        {
            Valor = value;
        }

        public Money Add(Money money)
        {
            return new Money(Valor + money.Valor);
        }

        public Money Subtract(Money money)
        {
            return new Money(Valor - money.Valor);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<Object>() { Valor };
        }
    }
}
