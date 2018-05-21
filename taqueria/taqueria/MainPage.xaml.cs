using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using scanner.cuerpos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace taqueria
{
	public partial class MainPage : ContentPage
	{
        string id;
        string idPhone1;
        public MainPage(string idPhone)
        {
            id = "8";
            new restClient().inserUser(Int32.Parse(id));
            idPhone1 = idPhone; 
            InitializeComponent();
            //id = idPhone;
            
            btnSucursales.Clicked += BtnSucursales_Clicked;
            btnMenu.Clicked += BtnMenu_Clicked;
            btnOrdenes.Clicked += BtnOrdenes_Clicked;
            btnPaLevar.Clicked += BtnPaLevar_Clicked;  
        }

        private void BtnPaLevar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("code",idPhone1,"aceptar");
           // Navigation.PushAsync(new PaLlevar1());
        }

        private void BtnOrdenes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ordenes(id));
        }

        private void BtnSucursales_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sucursales());
        }

        private void BtnMenu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu());
        }
    }
}
