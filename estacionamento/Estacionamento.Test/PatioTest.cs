using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Estacionamento.Test
{
    public class PatioTest
    {
        [Fact(DisplayName ="teste n 1")]
        [Trait("Funcionalidade", "Faturamento")]
        public void ValidaFaturamentoDoPatioCom1Veiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = "Nicolas",
                Tipo = TipoVeiculo.Automovel,
                Cor = "amarelo",
                Modelo = "fusca",
                Placa = "asd-9998"
            };

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
            Patio estacionamento = new();
            var veiculo = new Veiculo
            {
                Proprietario = proprietario,
                Placa = placa,
                Cor = cor,
                Modelo = modelo
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturento = estacionamento.TotalFaturado();

            //Assert

            Assert.Equal(2, faturento);
        }

        [Theory]
        [InlineData("Andre", "ASD-1234", "preto", "Gol")]

        public void LocalizaVeiculoNoPatioComBaseNoIdTicket( string proprietatio,
                                            string placa,
                                            string cor,
                                            string modelo)
        {

            //Arrange
            Patio estacionamento = new();
            var veiculo = new Veiculo
            {
                Proprietario = proprietatio,
                Placa = placa,
                Cor = cor,
                Modelo = modelo
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);


            //Act
            var consulta = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert 
            Assert.Contains("### Gerar ticket ###", consulta.Ticket);
        }

        [Fact]
        public void AlteraDadosDoVeiculo()
        {

            //Arrange
            Patio estacionamento = new();
            var veiculo = new Veiculo
            {
                Proprietario = "jose",
                Placa = "kcx-5456",
                Cor = "verde",
                Modelo = "opala",
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo
            {
                Proprietario = "jose",
                Placa = "kcx-5456",
                Cor = "verde",
                Modelo = "azul",
            };

            //Act
            Veiculo alterado = estacionamento.AlteraDadosDoVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);

        }
    }
}
