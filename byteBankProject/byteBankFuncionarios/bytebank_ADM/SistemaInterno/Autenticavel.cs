using bytebank_ADM.Funcionarios;

namespace bytebank_ADM.SistemaInterno
{
    public abstract class Autenticavel : Funcionario
    {
        public Autenticavel(string cpf, double salario) : base(cpf, salario)
        {
        }

        protected Autenticavel(double salario, string cpf) : base(salario, cpf)
        {
        }
        public string Senha { get; set; }
        public string Login { get; set; }
        public bool Autenticar(string login, string senha)
        {
            return (Senha == senha && Login == login);
        }
    }
}
