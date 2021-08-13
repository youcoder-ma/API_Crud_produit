using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Web_api_crud_produit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {
        HttpClient _client = new HttpClient();

        public Add()
        {
            InitializeComponent();
        }

        public async void Addproduit_Clicked(object sender, EventArgs e)
        {
            produit pt = new produit()
            {
                NameProduit = EntryNameProduit.Text,
                PrixProduit = float.Parse(EntryPrixProduit.Text),
                Quantite = int.Parse(EntryQuantite.Text)

            };

            var json = JsonConvert.SerializeObject(pt);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("http://10.0.2.2:44389/api/Produits", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("ADD", "Produit Added:)", "OK");

                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("ERREUR", "ERREUR :/", "OK");
            }
        }
    }
}