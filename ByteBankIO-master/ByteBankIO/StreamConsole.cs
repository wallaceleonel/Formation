partial class Program
{
    static void UsarStreamNoConsole()
    {
        using (var fluxo = Console.OpenStandardInput())
        using(var file = new FileStream("entradaDoConsole.txt", FileMode.Create))
        {
            var buffer = new byte[1024];

            while (true)
            {
                var bytesLidos = fluxo.Read(buffer, 0, 1024);
                Console.WriteLine($"Bytes lidos na console{bytesLidos}");
            }
        }
    }
}