﻿using RoastingBoulevard.Data;
using RoastingBoulevard.Models;
using RoastingBoulevard.ViewModels;
using System;
using System.Collections.Generic;
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
                if (e.Item == null) return;
                if (sender is ListView lv) lv.SelectedItem = null;
            };
            payButton.Clicked += (object sender, EventArgs e) =>
            {
                List<Food> foods = new List<Food>();
                List<int> amounts = new List<int>();
                foreach (FoodDeliveryContainer fdc in viewModel.FoodsContainer)
                {
                    foods.Add(fdc.Food);
                    amounts.Add(fdc.Amount);
                }

                Delivery delivery = new Delivery {
                    CreatedDate = DateTime.Today,
                    UserId = SharedData.user.Id,
                    Foods = foods,
                    Amounts = amounts
                };
                Tools.Tools.PushAsync("Metodo de pago", this.Navigation, new PayView(delivery));
            };
        }
        public void AddToList(Food food)
        {
            viewModel.AddFood(food);
        }

        public async void ShowAlertToErase(object sender, EventArgs e)
        {
            Food food = (Food)(((ImageButton)sender).CommandParameter);
            bool answer = await DisplayAlert("Borrar comida", "¿Seguro que quieres borrarla de la cesta?", "Si", "No");

            if (answer)
            {
                viewModel.RemoveFullFood(food);
            }
        }


    }
}
