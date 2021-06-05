using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double ValorDestino { get; }

        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            this.ValorDestino = valorDestino;
        }
        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                 .DefaultIfEmpty(new Lance(null, 0))
                 .Where(fsd => fsd.Valor > ValorDestino)
                 .OrderBy(fsd => fsd.Valor)
                 .FirstOrDefault();
        }
    }
}
