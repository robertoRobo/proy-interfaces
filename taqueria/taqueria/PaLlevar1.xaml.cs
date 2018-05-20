using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taqueria
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaLlevar1 : ContentPage
	{
        
        public PaLlevar1 ()
		{
			InitializeComponent ();

            btnBackSucursalesOrden.Clicked += BtnBackSucursalesOrden_ClickedAsync;
            btnSuc1.Clicked += BtnSuc1_Clicked;

        }

        private void BtnSuc1_Clicked(object sender, EventArgs e)
        {
            /*Navigation.PushAsync(new MenuOrden());*/
            
        }

        private async void BtnBackSucursalesOrden_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

            var toastConfig = new ToastConfig("Orden Cancelada");
            toastConfig.SetDuration(2000);
            toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(255, 52, 0));
            toastConfig.SetMessageTextColor(System.Drawing.Color.FromArgb(255, 255, 255));
            toastConfig.SetPosition(ToastPosition.Bottom);

            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}