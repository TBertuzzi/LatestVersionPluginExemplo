using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.LatestVersion;

namespace LatestVersionPluginExemplo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            btnVersao.Clicked += async (sender, e) => {

                //Verifica a versão atual do APP
                var isLatest = await CrossLatestVersion.Current.IsUsingLatestVersion();

                if (!isLatest)
                {
                    //Avisa o usuario que existe uma versão nova e pergunta se ele quer baixar
                    var update = await DisplayAlert("Nova versão disponivel", "Existe uma nova versão deste app,deseja atualizar?", "Sim", "Não");

                    if (update)
                    {
                        //Abre a Loja nativa da plataforma para efetur o Download
                        await CrossLatestVersion.Current.OpenAppInStore("NOME DO SEU APP");
                    }
                }
            };

            
        }
	}
}
