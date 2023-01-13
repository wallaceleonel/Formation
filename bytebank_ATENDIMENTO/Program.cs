using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.byteBank.Atendimento;
using bytebank_ATENDIMENTO.byteBank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

new ByteBankAtendimento().AtendimentoCliente();

#region exemplos de uso de arrays
//TestaArrayInt();

void TestaArrayInt()
{
}

//TestaBuscarPalavra();

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1} palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }
    Console.Write("Digite palavra a ser encontrada");
    var busca = Console.ReadLine();

    foreach (var palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"palavra encontada = {busca}.");
            break;
        }
    }
}

Array amostra = new double[5];

amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10.9, 3);
amostra.SetValue(6.8, 4);

//TestaMediana(amostra);
void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine(" Array esta vazio ou nulo");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Com banse na amostra a mediana é {mediana}");

}

void TestaArrayContaCorrentes()
{
    ListaContasCorrentes listaContas = new();
    listaContas.Adicionar(new ContaCorrente(874, "146151-q"));
    listaContas.Adicionar(new ContaCorrente(875, "146151-y"));
    listaContas.Adicionar(new ContaCorrente(876, "146151-z"));
    var contaGerencia = new ContaCorrente(969, "146151-x");
    listaContas.Adicionar(contaGerencia);
    listaContas.ExiirLista();

    for (int i = 0; i < listaContas.Tamanho; i++)
    {
        ContaCorrente conta = listaContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }
}

TestaArrayContaCorrentes();
#endregion

#region exemplos de uso do list
//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874, "5679787-A"),
//    new ContaCorrente(874, "4456668-B"),
//    new ContaCorrente(874, "7781438-C")
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951, "5679787-E"),
//    new ContaCorrente(321, "4456668-F"),
//    new ContaCorrente(719, "7781438-G")
//};

//_listaDeContas2.AddRange(_listaDeContas3);
//_listaDeContas2.Reverse();

//for (int i = 0; i < _listaDeContas2.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
//}

//var range = _listaDeContas3.GetRange(0, 1);
//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}

//_listaDeContas3.Clear();
//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}
#endregion