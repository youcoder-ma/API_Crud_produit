using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Web_api_crud_produit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Update : ContentPage
    {
        public Update()
        {
            InitializeComponent();
        }

        private void Updateproduit_Clicked(object sender, EventArgs e)
        {
            string Id = (sender as Xamarin.Forms.SwipeItem).CommandParameter.ToString();
            produit produit = new produit
            {
                NameProduit = EntryNameProduit.Text,
                PrixProduit = float.Parse(EntryPrixProduit.Text),
                Quantite = int.Parse(EntryQuantite.Text)
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(produit);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.PutAsync(string.Format("http://10.0.2.2:44389/api/Produits?id={0}", Id), httpContent);
            DisplayAlert("Added", "Your data has been Ipdated", "ok");
        }
    }
}