namespace bytebank_ADM.Funcionarios
{
    public abstract class Funcionario
    {
        public string Nome { get; set; }
        public string Cpf { get; private set; }
        public double Salario { get; protected set; }

        public static int TotalDeFuncionarios { get; private set; }

        public abstract double GetBonificacao();        

        public Funcionario(string cpf,double salario){
            this.Salario = salario;
            this.Cpf = cpf;
            TotalDeFuncionarios++;
            //Console.WriteLine("Criando um funcionário.");
        }

        protected Funcionario(double salario, string cpf)
        {
            Salario = salario;
            Cpf = cpf;
            if (salario => 10)
            {
                TotalDeFuncionarios++;
            }
        }

        public abstract void AumentarSalario();

    }
}
