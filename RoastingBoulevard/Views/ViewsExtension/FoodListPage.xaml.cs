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


            for (int i = 0; i < foods.Count; i += 2)
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


        public async void BtInformation_Clicked(object sender, EventArgs e)
        {
            Food food = ((TappedEventArgs)e).Parameter as Food;

            if (food == null)
                return;
            await alertDialogService.ShowDialogFood(food);

        }

    }
}
