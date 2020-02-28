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
	public partial class MinhasVagasCadastradas : ContentPage
	{
        List<Vaga> Lista { get; set; }
        public MinhasVagasCadastradas ()
		{
			InitializeComponent ();
            ConsultarVagas();
            
        }
        private void ConsultarVagas()
        {
            Database database = new Database();
            Lista = database.Consultar();
            ListaVagas.ItemsSource = Lista;

            LblCount.Text = Lista.Count.ToString();
        }
        public void EditarAction(object sender, EventArgs args)
        {
            Label LblEditar = (Label)sender;
            Vaga vaga = ((TapGestureRecognizer)LblEditar.GestureRecognizers[0]).CommandParameter as Vaga;
            Navigation.PushAsync(new EditarVaga(vaga));
        }
        public void ExcluirAction(object sender, EventArgs args)
        {
            Label LblExluir = (Label)sender;
            Vaga vaga = ((TapGestureRecognizer)LblExluir.GestureRecognizers[0]).CommandParameter as Vaga;

            Database database = new Database();
            database.Exclusao(vaga);

            ConsultarVagas();
        }
        private void PesquisarAction(object sender, TextChangedEventArgs e)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.Contains(e.NewTextValue)).ToList();

        }

    }
}