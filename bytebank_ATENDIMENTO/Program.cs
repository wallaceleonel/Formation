using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.byteBank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

//TestaArrayInt();

void TestaArrayInt()    
{
}

//TestaBuscarPalavra();

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i< arrayDePalavras.Length; i ++)
    {
        Console.Write($"Digite {i + 1} palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }
    Console.Write("Digite palavra a ser encontrada");
    var busca = Console.ReadLine();

    foreach(var palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"palavra encontada = {busca}.");
            break;
        }
    }
}

//Array amostra = new double[5];

//amostra.SetValue(5.9, 0);
//amostra.SetValue(1.8, 1);
//amostra.SetValue(7.1, 2);
//amostra.SetValue(10.9, 3);
//amostra.SetValue(6.8, 4);
//amostra.SetValue(7.9, 5);

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
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :( numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Com banse na amostra a mediana é {mediana}");

}

void TestaArrayContaCorrentes()
{
    ListaContasCorrentes listaContas = new ();
    listaContas.Adicionar(new ContaCorrente(874));
    listaContas.Adicionar(new ContaCorrente(875));
    listaContas.Adicionar(new ContaCorrente(876));

}

TestaArrayContaCorrentes();
