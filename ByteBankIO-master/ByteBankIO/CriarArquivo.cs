using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        var caminhoArquivo = "contasExportadas.csv";

        using(var fluxoArquivo = new FileStream(caminhoArquivo, FileMode.Create))
        {
            var contaComoString = "456,7895, 4785.40, gustamo gusmão";

            var enconding = Encoding.UTF8;

            var bytes = enconding.GetBytes(contaComoString);

            fluxoArquivo.Write(bytes, 0, bytes.Length);

        }
    }

    static void CriarArquvoComWriter()
    {
        var caminhoDoArquvo = "contasExportadas.csv";
        using(var fluxoArquivo = new FileStream(caminhoDoArquvo, FileMode.Create))
        using(var escritor = new StreamWriter(fluxoArquivo))
        {
            escritor.Write("escritor cadastrado");
        }
    }

    static void TestaEscrita()
    {
        var caminhoDoArquvo = "test.csv";
        using (var fluxoArquivo = new FileStream(caminhoDoArquvo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoArquivo))
        { 
            for (int i = 0; i< 100; i++)
            {
                escritor.WriteLine($"linha {i}");
                escritor.Flush(); //Dispeja o buffer para o Stream
                Console.ReadLine();
            }
        }
    }
}