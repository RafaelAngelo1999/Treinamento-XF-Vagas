using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Vagas.Banco;
using System.IO;
using Vagas.iOS.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace Vagas.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoBibioteca = Path.Combine(caminhoDaPasta, "..", "Library");
            string caminhoBanco = Path.Combine(caminhoBibioteca,NomeArquivoBanco);
            return caminhoBanco;
        }
    }
}