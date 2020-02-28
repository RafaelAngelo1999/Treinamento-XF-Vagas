using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vagas.Modelos;
using Vagas.Banco;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastrarVaga : ContentPage
	{
		public CadastrarVaga ()
		{
			InitializeComponent ();
		}

        private void SalvarAction(object sender, EventArgs e)
        {
            //Obter dados da tela
            Vaga vaga = new Vaga();
            vaga.NomeVaga = NomeVagas.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Cidade = Cidade.Text;
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Empresa = Empresa.Text;
            vaga.Descricao = Descricao.Text;
            vaga.TipoContratacao = (TipoContracao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;

            //Salvar informações no banco

            Database database = new Database();
            database.Cadastro(vaga);

            //TODO - Voltar para tela inicial

            App.Current.MainPage = new NavigationPage(new ConsultarVagas());
        }
    }
}