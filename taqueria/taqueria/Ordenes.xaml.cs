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

namespace taqueria
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Ordenes : ContentPage
	{
        private ObservableCollection<OrdenModel> order { get; set; }
        int identificador_telefono;
        //restClient cliente = new restClient();
        List<orden> resp;
        string desc = "";
        
        public Ordenes (string id)
		{
            identificador_telefono = Int32.Parse(id);
			InitializeComponent ();
            order = new ObservableCollection<OrdenModel>();

            BtnBackOrdenes.Clicked += BtnBackOrdenes_Clicked;

            resp = new restClient().getOrden(identificador_telefono);
            if (resp != null)
            {
                List<orden> pedido = new List<orden>();
                //desc = "";
                // listOrden.ItemsSource = resp[0].descripcion.Split(',');
                foreach (orden simple in resp ) {
                    orden1.Text = "Orden #"+simple.num_orden.ToString();
                    if (simple.id_sucursal == 1)
                    {
                        sucursal1.Text = "Sucursal Centro";
                    } else if (simple.id_sucursal == 2) {
                        sucursal1.Text = "Sucursal Feria";
                    }
                    else
                    {
                        sucursal1.Text = "Sucursal Morelos";
                    }
                    total1.Text = "$ "+simple.total.ToString();
                    fecha1.Text = simple.fecha.Day + "/" + simple.fecha.Month + "/" + simple.fecha.Year;

                    foreach (string plato in simple.descripcion.Split(','))
                    {
                        // desc += "{" + plato.Split('(')[0]+" "+ plato.Split('(')[1] + "}";
                        pedido.Add(new orden() { descripcion = plato.Split('(')[0], cantidad = plato.Split('(')[1] });
                    }
                }
                

                listOrden.ItemsSource = pedido;
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

            order.Add(new OrdenModel() { Platillo = "Taco Al Pastor", Cantidad = "Cantidad: 20"});
            order.Add(new OrdenModel() { Platillo = "Taco Suadero", Cantidad = "Cantidad: 15" });
            order.Add(new OrdenModel() { Platillo = "Torta Al Pastor", Cantidad = "Cantidad: 1" });
            order.Add(new OrdenModel() { Platillo = "Torta Suadero", Cantidad = "Cantidad: 3" });
            order.Add(new OrdenModel() { Platillo = "Torta Suadero", Cantidad = "Cantidad: 3" });
            order.Add(new OrdenModel() { Platillo = "Torta Suadero", Cantidad = "Cantidad: 3" });
            order.Add(new OrdenModel() { Platillo = "Torta Suadero", Cantidad = "Cantidad: 3" });

        }

        private void BtnBackOrdenes_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("hola",desc , "acept");
            //DisplayAlert("hoa", resp[0].descripcion, "aceptar");
            Navigation.PopAsync();
        }
    }
}