using PrimeiraApi;
using Xunit;

namespace PrimeiraApi.Tests.Negocio.Util
{
    public class CPF
    {
        [Theory]
        [InlineData("12345678901")]
        [InlineData("11111111111")]
        [InlineData("99999999999")]
        public void ValidaCPF_ValidCPF_ReturnsTrue(string cpf)
        {
            // Act
            bool isValid = CPF.ValidaCPF(cpf);

            // Assert
            Assert.True(isValid);
        }

        private static bool ValidaCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData("12345678900")]
        [InlineData("00000000000")]
        [InlineData("99999999990")]
        public void ValidaCPF_InvalidCPF_ReturnsFalse(string cpf)
        {
            // Act
            bool isValid = CPF.ValidaCPF(cpf);

            // Assert
            Assert.False(isValid);
        }
    }
}