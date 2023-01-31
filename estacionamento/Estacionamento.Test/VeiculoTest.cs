using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Estacionamento.Test
{
    public class VeiculoTeste
    {
        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Acert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFreiarComParametro10()
        {
            //Arrange
            var veiculo  = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            var carro = new Veiculo
            {
                Tipo = TipoVeiculo.Automovel,
                Proprietario = "Wallace",
                Placa = "ZAP-7419",
                Cor = "Azul",
                Modelo = "Variante"
            };

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Ficha do veiculo:", dados);
        }

        [Fact]
        public void TestaMessagemDeExececaoDoQuartoCaracterDaPlaca()
        {
            //Arrange
            string placa = "ASDF5505";

            //Act
            var menssagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placa
                );
            
            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", menssagem.Message);
        }

        [Fact]
        public void TestaUltimosCaracteresPlacaVeiculoComoNumeros()
        {
            //Arrange
            string placaFormatoErrado = "ASD-995U";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo().Placa = placaFormatoErrado
            );

        }
    }
}
