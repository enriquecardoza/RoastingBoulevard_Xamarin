using RoastingBoulevard.Data;
using RoastingBoulevard.Helpers;
using RoastingBoulevard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoastingBoulevard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PayView : ContentPage
    {
        public PayView()
        {
            InitializeComponent();

        }
        public PayView(Delivery delivery)
        {
            InitializeComponent();

            pickerMethod.SelectedIndexChanged += ChangueEnterDataVisibility();
            payButton.Clicked += Pay(delivery);
        }

        private EventHandler ChangueEnterDataVisibility()
        {
            return (object sender, EventArgs e) =>
            {
                if (pickerMethod.SelectedIndex == 0)
                {
                    enterDataGrid.IsVisible = false;
                }
                else
                {
                    enterDataGrid.IsVisible = true;
                }
            };
        }

        private EventHandler Pay(Delivery delivery)
        {
            return async (object sender, EventArgs e) =>
            {
                delivery.PaymentMethod = pickerMethod.SelectedIndex;
                //subir datos
                //cambiar pestaña de la cesta por la del pedido
                await DeliveryHelperAzure.InsertDelivery(delivery);
                SharedData.actualDelivery = delivery;
                Tools.Tools.PopToRootAsync(Navigation);
            };
        }
    }
}
