using bytebank_ADM.SistemaInterno;

namespace bytebank_ADM.Funcionarios
{
    public class GerenteDeContas : Autenticavel
    {       

        public GerenteDeContas(string cpf) : base(cpf,4000)
        {
        }
        public override double GetBonificacao()
        {
            return this.Salario * 0.25;
        }

        public override void AumentarSalario()
        {
            this.Salario *= 1.05;
        }

        public override bool Autenticar(string senha)
        {
            return this.Senha == senha;
        }
    }
}
