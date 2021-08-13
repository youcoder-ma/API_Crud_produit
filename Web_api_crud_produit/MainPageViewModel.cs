using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Web_api_crud_produit
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        

        public MainPageViewModel()
        {
            GetProduits();
        }



        public async void GetProduits()
        {
            using (var client = new HttpClient())
            {

                var uri = "http://10.0.2.2:44389/api/Produits"; 
                var result = await client.GetStringAsync(uri);

                var ProduitList = JsonConvert.DeserializeObject<List<produit>>(result);
                Produits = new ObservableCollection<produit>(ProduitList);
            }
        }

        ObservableCollection<produit> _produits;
        public ObservableCollection<produit> Produits
        {
            get
            {
                return _produits;
            }
            set
            {
                _produits = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        






    }
}
