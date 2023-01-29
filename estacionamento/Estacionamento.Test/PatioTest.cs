using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Estacionamento.Test
{
    public class PatioTest
    {
        [Fact]
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
    }

}
