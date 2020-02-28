using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vagas.Banco;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Vagas.Modelos;

namespace Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarVagas : ContentPage
    {
        List<Vaga> Lista {get;set;}
		public ConsultarVagas ()
		{
			InitializeComponent ();
            Database database = new Database();
            Lista = database.Consultar();
            ListaVagas.ItemsSource = Lista;

            LblCount.Text = Lista.Count.ToString();
		}
        private void GoCadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastrarVaga());
        }

        private void GoVagas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MinhasVagasCadastradas());
        }

        private void MaisDetalheAction(object sender, EventArgs e)
        {
            Label LblDetalhe = (Label)sender;
            Vaga vaga = ((TapGestureRecognizer)LblDetalhe.GestureRecognizers[0]).CommandParameter as Vaga;
            Navigation.PushAsync(new DetalharVaga(vaga));
        }

        private void PesquisarAction(object sender, TextChangedEventArgs e)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.Contains(e.NewTextValue)).ToList();
            
        }
    }
}