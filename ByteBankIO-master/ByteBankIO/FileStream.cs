using System.Text;

partial class Program
{
    static void FileStream()
    {
        var contasArquivo = "contas.txt";

        using (var fluxoDoArquvo = new FileStream(contasArquivo, FileMode.Open))
        {
            var numeroDeBytes = -1;

            var buffer = new byte[1024]; // 1kb

            while (numeroDeBytes != 0)
            {
                numeroDeBytes = fluxoDoArquvo.Read(buffer, 0, 1024);

                Console.WriteLine($"numero de bytes lidos {numeroDeBytes}");
                EscreverBuffer(buffer, numeroDeBytes);
            }

            fluxoDoArquvo.Close();

            Console.ReadLine();
        }
    }
    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding();
        var texto = utf8.GetString(buffer, 0, bytesLidos);


        Console.WriteLine(texto);

        /*
        foreach (var meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(' ');
        }
        */
    }
}