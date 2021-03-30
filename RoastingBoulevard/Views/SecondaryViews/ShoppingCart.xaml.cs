using RoastingBoulevard.Data;
using RoastingBoulevard.Models;
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
        public ShoppingCartViewModel viewModel = new ShoppingCartViewModel();
        public static ShoppingCart instance;
        public ShoppingCart()
        {
            InitializeComponent();
            instance = this;
            viewModel = new ShoppingCartViewModel();
            mainPage.BindingContext = viewModel;
            MyListView.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                // don't do anything if we just de-selected the row.

                if (e.Item == null) return;

                if (sender is ListView lv) lv.SelectedItem = null;
            };
        }
        /*
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }
        */
        public void AddToList(Food food)
        {
            viewModel.AddFood(food);
        }

        public async void ShowAlertToErase(object sender, EventArgs e)
        {
            Food food = (Food)(((ImageButton)sender).CommandParameter);
            bool answer = await DisplayAlert("Borrar comida", "¿Seguro que quieres borrarla de la cesta?" , "Si", "No");

            if (answer)
            {
                viewModel.RemoveFullFood(food);
            }
        }


    }
}
