using bytebank.Modelos.Conta;

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
            MaiorSaldo(); 
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

        public ContaCorrente MaiorSaldo()
        {

            ContaCorrente conta = null;
            double maiorValor = 0;
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    if (!(maiorValor > _itens[i].Saldo))
                    {

                        conta = _itens[i];
                    }
                }

            }
            return conta;
        }

        public void Remover( ContaCorrente conta)
        {
            int indiceItem = -1; ;
            for(int i = 0; i< _proximaPosicao; i++)
            {
                ContaCorrente contaAtual = _itens[i];
                if(contaAtual == conta) 
                {
                    indiceItem= i;  
                    break;  
                }
            }
            
            for (int i = indiceItem; i< _proximaPosicao-1; i++)
            {
                _itens[i] = _itens[i +1]; 
            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void ExiirLista()
        {
            for(int i = 0; i < _itens.Length; i ++)
            {
                if (_itens[i] != null)
                {
                    var conta = _itens[i];
                    Console.WriteLine($" Indice[{i}] = conta : {conta.Conta} agencia : {conta.Numero_agencia}");
                }
            }
        }

        public ContaCorrente RecuperarComtaNoIndice(int indice)
        {
            if(indice<0 || indice>= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];
        }

        public int Tamanho 
        {
            get
            {
                return _proximaPosicao;   
            }
                
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return RecuperarComtaNoIndice(indice);
            }
        }
    }
}
