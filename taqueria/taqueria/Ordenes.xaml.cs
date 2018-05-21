using Newtonsoft.Json;
using scanner.cuerpos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taqueria.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace taqueria
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Ordenes : ContentPage
	{
        private ObservableCollection<OrdenModel> order { get; set; }
        string identificador_telefono;
        ZXingBarcodeImageView barcode;
        //restClient cliente = new restClient();
        List<orden> resp;
        //eticaquetas usadas en el stack
        
        public Ordenes (string id)
		{
            identificador_telefono = id;
			InitializeComponent ();
           
            order = new ObservableCollection<OrdenModel>();

            BtnBackOrdenes.Clicked += BtnBackOrdenes_Clicked;
            resp = new restClient().getOrden(identificador_telefono);
            if (resp != null)
            {
                int cont = 0;
                foreach (orden simple in resp)
                {
                    if (cont == 0)
                    {
                        ordenes.IsEnabled = true;
                        ordenes.IsVisible = true;
                        crearStack(orden1, sucursal1, total1, fecha1, qrResult, listOrden, simple);
                    }
                    else if (cont == 1) {
                        ordenes2.IsEnabled = true;
                        ordenes2.IsVisible = true;
                        crearStack(orden2, sucursal2, total2, fecha2, qrResult2, listOrden2, simple);
                    }
                    else if (cont == 2)
                    {
                        ordenes3.IsEnabled = true;
                        ordenes3.IsVisible = true;
                        crearStack(orden3, sucursal3, total3, fecha3, qrResult3, listOrden3, simple);
                    }
                    else if (cont == 3)
                    {
                        ordenes4.IsEnabled = true;
                        ordenes4.IsVisible = true;
                        crearStack(orden4, sucursal3, total4, fecha4, qrResult4, listOrden4, simple);
                    }
                    cont += 1;
                }
            }
            else
            {
                ordenes.IsVisible = false;
            }

            var imgPromociones = new List<string> {
                "promo.jpg",
                "QRCode.png"
            };
            Promos.ItemsSource = imgPromociones;
          
           // listOrden.ItemsSource = order;
            /*foreach (orden parte in resp) {
                desc += "{" + parte.descripcion+"}";
            }*/
            /*order.Add(new OrdenModel() { Platillo = "Taco Al Pastor", Cantidad = "Cantidad: 20"});
            order.Add(new OrdenModel() { Platillo = "Taco Suadero", Cantidad = "Cantidad: 15" });
            order.Add(new OrdenModel() { Platillo = "Torta Al Pastor", Cantidad = "Cantidad: 1" });
            order.Add(new OrdenModel() { Platillo = "Torta Suadero", Cantidad = "Cantidad: 3" });
            order.Add(new OrdenModel() { Platillo = "Torta Suadero", Cantidad = "Cantidad: 3" });
            order.Add(new OrdenModel() { Platillo = "Torta Suadero", Cantidad = "Cantidad: 3" });
            order.Add(new OrdenModel() { Platillo = "Torta Suadero", Cantidad = "Cantidad: 3" });*/
        }
        private void incializar() {
            ordenes.IsEnabled = false;
            ordenes.IsVisible = false;
            ordenes2.IsEnabled = false;
            ordenes2.IsVisible = false;
            ordenes3.IsEnabled = false;
            ordenes3.IsVisible = false;
            ordenes4.IsEnabled = false;
            ordenes4.IsVisible = false;

        }
        private void crearStack(Label orden1,Label sucursal1,Label total1,Label fecha1,ContentView qrResult,ListView listOrden,orden simple) {
                List<orden> pedido = new List<orden>();
                
                    orden1.Text = "Orden #" + simple.num_orden.ToString();
                    if (simple.id_sucursal == 1)
                    {
                        sucursal1.Text = "Sucursal Centro";
                    }
                    else if (simple.id_sucursal == 2)
                    {
                        sucursal1.Text = "Sucursal Feria";
                    }
                    else
                    {
                        sucursal1.Text = "Sucursal Morelos";
                    }
                    total1.Text = "$ " + simple.total.ToString();
                    fecha1.Text = simple.fecha.Day + "/" + simple.fecha.Month + "/" + simple.fecha.Year;
                    generaQr(qrResult, simple.codigo);
                    foreach (string plato in simple.descripcion.Split(','))
                    {
                        // desc += "{" + plato.Split('(')[0]+" "+ plato.Split('(')[1] + "}";
                        pedido.Add(new orden() { descripcion = plato.Split('(')[0], cantidad = plato.Split('(')[1] });
                    }
                
                listOrden.ItemsSource = pedido;
           
        }
        private void generaQr(ContentView qrResult,string codigo) {
            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 100;
            barcode.BarcodeOptions.Height = 100;
            barcode.BarcodeValue = codigo.Trim();
            qrResult.Content = barcode;
            qrResult.WidthRequest = 100;
            qrResult.HeightRequest = 100;
        }

        private void BtnBackOrdenes_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("hola",desc , "acept");
            //DisplayAlert("hoa", resp[0].descripcion, "aceptar");
            Navigation.PopAsync();
        }
    }
}