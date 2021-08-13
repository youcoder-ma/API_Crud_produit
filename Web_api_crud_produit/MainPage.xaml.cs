using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Web_api_crud_produit
{
    public partial class MainPage : ContentPage
    {
        HttpClient client;
        

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
            client = new HttpClient();

        }

        public async void DeleteProduitAsync(object sender, EventArgs e)
        {
           
            int id = int.Parse(((sender as Xamarin.Forms.SwipeItem).CommandParameter.ToString()));
            MainPageViewModel mainPageViewModel = new MainPageViewModel();
            
            HttpClient httpClient = new HttpClient();

            

            var uri = new Uri("http://10.0.2.2:44389/api/Produits/" + id);

            var response = await httpClient.DeleteAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("DELETE","Produit deleted:)","OK");

                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("ERREUR", "ERREUR :/", "OK");
            }

            
           
        }

        //Add Product

        private void Navigate_Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add());
        }


        private void Navigate_Update(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Update());
        }

    }
}
