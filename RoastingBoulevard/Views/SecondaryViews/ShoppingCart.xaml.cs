using RoastingBoulevard.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoastingBoulevard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingCart : ContentPage
    {
        ShoppingCartViewModel viewModel = new ShoppingCartViewModel();
        public ShoppingCart()
        {
            InitializeComponent();

            MyListView.ItemsSource = viewModel.Foods;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }
    }
}
