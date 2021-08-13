using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;

namespace Web_api_crud_produit.Droid
{
    [Activity(Label = "Web_api_crud_produit", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {


        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    Forms.SetFlags("SwipeView_Experimental");

        //    base.OnCreate(savedInstanceState);


        //    global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

        //    TabLayoutResource = Resource.Layout.Tabbar;
        //    ToolbarResource = Resource.Layout.Toolbar;

        //    base.OnCreate(savedInstanceState);

        //    Xamarin.Essentials.Platform.Init(this, savedInstanceState);

        //    LoadApplication(new App());
        //}


        protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);

                Forms.SetFlags("SwipeView_Experimental"); // Add here
                global::Xamarin.Forms.Forms.Init(this, bundle);

                LoadApplication(new App());
            }
            
       



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}