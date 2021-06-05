using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arrange - cenário
            //Dado leilão sem nenhum lance
            var leilao = new Leilao("Van Gogh");

            //Act - método sob teste
            //Quando o leilão termina
            leilao.TerminaPregao();

            //Assert
            //Então o valor esperado é zero
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(1200,new double[]{800, 900, 1000, 1200})]
        [InlineData(1000,new double[] {800,900,1000,990 })]
        [InlineData(800,new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas)
        {
            //Arrange - cenário
            //Dado leilão com lances sem ordem de valor
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }
            //Act - método sob teste
            //Quando o leilão termina
            leilao.TerminaPregao();

            //Assert
            //Então o valor esperado é o maior valor
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);

        }

    }
}
