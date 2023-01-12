using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.byteBank.Util
{
    public class ListaContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int  _proximaPosicao = 0;

        public ListaContasCorrentes(int tamanhoInicial = 5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine($" Indice  - Conta atual {_proximaPosicao}");
            VerrificaCapacidade(_proximaPosicao);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        private void VerrificaCapacidade(int tamanoPermitido)
        {
            if(_itens.Length >= tamanoPermitido)
            {
                return;
            }
            Console.WriteLine("Aumentando a capaciadade da lista");
            ContaCorrente[] novoArray = new ContaCorrente[tamanoPermitido];

            for ( int i = 0; i < _itens.Length; i++ )
            {
                novoArray[i] = _itens[i];
            }
            _itens= novoArray;
        }
    }
}
