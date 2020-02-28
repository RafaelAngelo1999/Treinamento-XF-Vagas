using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vagas.Modelos;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalharVaga : ContentPage
	{
		public DetalharVaga (Vaga vaga)
		{
			InitializeComponent ();

            BindingContext = vaga;
		}
	}
}