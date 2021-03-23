using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RoastingBoulevard.Models;
using RoastingBoulevard.Tools;
using RoastingBoulevard.ViewModels;
using Xamarin.Forms;

namespace RoastingBoulevard.Views
{
    public partial class FoodListPage : ContentPage
    {
        private readonly IAlertDialogService alertDialogService;
        public FoodListPage(List<Food> foods)
        {
            alertDialogService = DependencyService.Get<IAlertDialogService>();
            InitializeComponent();
            ObservableCollection<FoodCombine> fc = new ObservableCollection<FoodCombine>();


            for (int i = 0; i < foods.Count; i+=2)
            {
                if (i + 1 < foods.Count)
                    fc.Add(new FoodCombine(foods[i], foods[i + 1]));
                else
                    fc.Add(new FoodCombine(foods[i], null));
            }
            FoodCombineViewModel fcvm = new FoodCombineViewModel();
            fcvm.FoodsCombined = fc;
            foodListPage.BindingContext = fcvm;
        }

        /*
        private async void BtInformation_Clicked(object sender, EventArgs e)
        {
            await alertDialogService.ShowDialogAsync("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed venenatis.", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar imperdiet pharetra. Etiam id laoreet turpis. Sed a sodales nibh, a finibus ipsum. Phasellus nisl magna, congue ac risus in, rutrum faucibus tellus. Suspendisse non vestibulum felis, eget luctus nisi. Etiam efficitur tristique ipsum, eget blandit purus maximus eget. Vestibulum non elit magna. Cras dictum at enim sed hendrerit. Donec commodo diam eget mi commodo, sed consequat tellus iaculis. Pellentesque elementum enim odio, at ultrices nunc venenatis sit amet. Nulla venenatis felis id dui rutrum, et maximus nulla molestie. Aenean convallis, diam a aliquam porttitor, sapien turpis venenatis purus, ut cursus orci sapien sit amet orci. Nulla imperdiet lorem consectetur nunc congue accumsan", "Cerrar");
        }

        private async void BtConfirmation_Clicked(object sender, EventArgs e)
        {
            bool result = await alertDialogService.ShowDialogConfirmationAsync("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed venenatis.", $"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pulvinar imperdiet pharetra. Etiam id laoreet turpis. Sed a sodales nibh, a finibus ipsum. Phasellus nisl magna, congue ac risus in, rutrum faucibus tellus. Suspendisse non vestibulum felis, eget luctus nisi. Etiam efficitur tristique ipsum, eget blandit purus maximus eget. Vestibulum non elit magna. Cras dictum at enim sed hendrerit. Donec commodo diam eget mi commodo, sed consequat tellus iaculis. Pellentesque elementum enim odio, at ultrices nunc venenatis sit amet. Nulla venenatis felis id dui rutrum, et maximus nulla molestie. Aenean convallis, diam a aliquam porttitor, sapien turpis venenatis purus, ut cursus orci sapien sit amet orci.{Environment.NewLine}¿Desea continuar?", "No", "Si");
            LbResult.Text = result ? "Resultado confirmación: Si" : "Resultado confirmación: No";
        }*/
    }
}
