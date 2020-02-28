using System;
using System.Collections.Generic;
using System.Text;

namespace Vagas.Banco
{
    public interface ICaminho
    {
        string ObterCaminho(string NomeArquivoBanco);
    }
}
