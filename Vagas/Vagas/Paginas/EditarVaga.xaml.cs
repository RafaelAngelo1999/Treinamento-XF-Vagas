using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vagas.Banco;
using Vagas.Modelos;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarVaga : ContentPage
	{
        private Vaga vaga { get; set; }
		public EditarVaga (Vaga vaga)
		{
			InitializeComponent ();
            this.vaga = vaga;

            NomeVagas.Text = vaga.NomeVaga;
            Empresa.Text = vaga.Empresa;
            Quantidade.Text = vaga.Quantidade.ToString();
            Cidade.Text = Cidade.Text;

            Salario.Text = vaga.Salario.ToString();

            Descricao.Text = vaga.Descricao;
            TipoContracao.IsToggled = (vaga.TipoContratacao == "CLR") ? false : true;
            Telefone.Text = vaga.Telefone.ToString();
            Email.Text = vaga.Email;

            
		}

        public void SalvarAction(object sender, EventArgs e)
        {
            vaga.NomeVaga = NomeVagas.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Cidade = Cidade.Text;
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Empresa = Empresa.Text;
            vaga.Descricao = Descricao.Text;
            vaga.TipoContratacao = (TipoContracao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;

            Database database = new Database();
            database.Atualizacao(vaga);

            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());
            //TODO - Obter dados da tela
            //TODO - Atualizar
            //TODO - Redimencionar 

        }
    }
}