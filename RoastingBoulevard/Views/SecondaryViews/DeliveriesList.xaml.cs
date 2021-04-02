using RoastingBoulevard.ViewModels;
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
    public partial class DeliveriesList : ContentPage
    {
        public DeliveriesList()
        {
            InitializeComponent();
            MainGrid.BindingContext = new DeliveryListViewModel();
            MainGrid.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                if (e.Item == null) 
                    return;
                if (sender is ListView lv) 
                    lv.SelectedItem = null;
            };
        }
    }
}