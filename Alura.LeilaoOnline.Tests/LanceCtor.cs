using Alura.LeilaoOnline.Core;
using Xunit;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arrange - cenário
            var valorNegativo = -100;

            //Assert
            Assert.Throws<System.ArgumentException>(
                //Act
                () => new Lance(null, valorNegativo)
               );
        }
    }
}
