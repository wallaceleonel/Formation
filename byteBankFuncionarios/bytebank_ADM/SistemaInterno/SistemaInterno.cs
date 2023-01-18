namespace bytebank_ADM.SistemaInterno
{
    internal class SistemaInterno
    {
        public bool Logar(Autenticavel funcionario, string senha, string login)
        {
            bool usuarioAutenticado = funcionario.Autenticar(login, senha);
            if (usuarioAutenticado)
            {
                Console.WriteLine("Bem-vindo ao sistema!");
                return true;
            }
            else
            {
                Console.WriteLine("Senha incorreta!");
                return false;
            }
        }

    }
}
