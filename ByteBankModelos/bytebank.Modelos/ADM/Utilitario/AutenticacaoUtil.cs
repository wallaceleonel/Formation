using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankModelos.bytebank.Modelos.ADM.Utilitario
{
    internal class AutenticacaoUtil
    {
        public bool ValidarSenha(string senha, string senhaTentativa)
        {
            return senha.Equals(senhaTentativa);
        }
    }
}
