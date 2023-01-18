using ByteBankIO;

partial class Program
{
    static void StreamReader()
    {
        var arquivo = "contas.txt";

        using (var fluxoArquvo = new FileStream(arquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoArquvo);

            var arquivoCompleto = leitor.ReadToEnd();

            var numero = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringEmConta(linha);

                var msg = $"{contaCorrente.Titular}: conta numero {contaCorrente.Numero}, ag {contaCorrente.Agencia}, saldo {contaCorrente.Saldo}";

                Console.WriteLine(msg);

            }
        }
        Console.ReadLine();
    }

    static ContaCorrente ConverterStringEmConta(string linha)
    {
        var campo = linha.Split(',');

        var agencia = campo[0];
        var numero = campo[1];
        var saldo = campo[2].Replace('.', ',');
        var nomeTitular = campo[3];

        var agenciaCovert = int.Parse(agencia);
        var numetoConvert = int.Parse(numero);
        var saldoConvert = double.Parse(saldo);


        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaCovert, numetoConvert);
        resultado.Depositar(saldoConvert);
        resultado.Titular = titular;

        return resultado;
    }
}