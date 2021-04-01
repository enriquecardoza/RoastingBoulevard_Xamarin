using RoastingBoulevard.Data;
using RoastingBoulevard.Helpers;
using RoastingBoulevard.Models;
using RoastingBoulevard.Tools;
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
        private readonly IAlertDialogService alertDialogService;
        public PayView()
        {
            InitializeComponent();
        }
        public PayView(Delivery delivery)
        {
            InitializeComponent();

            pickerMethod.SelectedIndex = 0;
            pickerMethod.SelectedItem = pickerMethod.Items[0];
            pickerMethod.SelectedIndexChanged += ChangueEnterDataVisibility();
            payButton.Clicked += Pay(delivery);
            enterDataGrid.IsVisible = false;
            alertDialogService = DependencyService.Get<IAlertDialogService>();
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
                await Navigation.PopToRootAsync();
                MainTabbedPage.instance.HideShoppingCart();
                delivery.PaymentMethod = pickerMethod.SelectedIndex;
                await DeliveryHelperAzure.InsertDelivery(delivery);
                SharedData.actualDelivery = delivery;
                await alertDialogService.ShowDialogDelivering();
                Tools.Tools.PopToRootAsync(Navigation);
            };
        }
    }
}
