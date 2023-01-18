using ByteBankIO;
partial class Program
{
    static void EscritaBinaria()
    {
        using (var file = new FileStream("contaCorrente.txt", FileMode.Create))
        using (var escritor = new BinaryWriter(file))
        {
            escritor.Write(456);
            escritor.Write(5454545);
            escritor.Write(2500.50);
            escritor.Write("ramilton braga");
        }
    }

    static void LeituraBinaria()
    {
        using (var file = new FileStream("contaCorrente.txt", FileMode.Open))
        using (var leitor = new BinaryReader(file))
        {
            var agencia = leitor.ReadInt32();
            var numeroConta = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"{agencia}/{numeroConta}, {saldo}, {titular}");
        }

    }
}