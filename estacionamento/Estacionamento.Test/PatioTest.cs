using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Estacionamento.Test
{
    public class PatioTest
    {
        [Fact(DisplayName ="teste n 1")]
        [Trait("Funcionalidade", "Faturamento")]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Nicolas";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "amarelo";
            veiculo.Modelo = "fusca";
            veiculo.Placa = "asd-9998";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double Faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, Faturamento);
        }


        [Theory]
        [InlineData("Andre", "ASD-1234", "preto", "Gol")]
        [InlineData("Julia", "WAL-2609", "azul", "Fox")]
        [InlineData("Nicolas", "GTA-1157", "preto", "Fusca")]
        public void ValidarFaturamentoDeVariosVeiculos(string proprietario,
                                                       string placa,
                                                       string cor,
                                                       string modelo)
        {

            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa; 
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturento = estacionamento.TotalFaturado();

            //Assert

            Assert.Equal(2, faturento);
        }
    }
}
