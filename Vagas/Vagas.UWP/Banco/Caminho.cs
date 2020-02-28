using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Vagas.Banco;
using System.IO;
using Vagas.UWP.Banco;
using Windows.Storage;

[assembly: Dependency(typeof(Caminho))]
namespace Vagas.UWP.Banco
{
    class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string caminhoDaPasta = ApplicationData.Current.LocalFolder.Path;
            string caminhoBanco = Path.Combine(caminhoDaPasta, NomeArquivoBanco);
            return caminhoBanco;
        }
    }
}
