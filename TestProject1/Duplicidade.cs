using PrimeiraApi;
using Xunit;

namespace PrimeiraApi.Tests.Negocio.Util
{
    public class CPFTests
    {
        [Fact]
        public void ValidaCPF_DuplicatedCPF_ReturnsFalse()
        {
            // Arrange
            string cpf = "12345678901";

            // Act
            bool isValid = CPFTests.ValidaCPF(cpf);

            // Assert
            Assert.False(isValid);
        }

        private static bool ValidaCPF(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}