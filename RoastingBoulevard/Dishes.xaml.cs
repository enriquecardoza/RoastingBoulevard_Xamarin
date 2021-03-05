using System;
using System.Collections.Generic;
using RoasingBoulevard_Xamarin.Models;
using RoastingBoulevard.Models;
using RoastingBoulevard.Tools;
using Xamarin.Forms;

namespace RoastingBoulevard
{
    public partial class Dishes : ContentPage
    {
        public Dishes()
        {
            InitializeComponent();
            List<FoodCombine> list = new List<FoodCombine>();
            for(int i=0;i< TestData.GetSnacks().Count; i += 2)
            {
                //FoodCombine food = new FoodCombine(TestData.GetSnacks()[i], TestData.GetSnacks()[i + 1]);
                FoodCombine food = new FoodCombine(TestData.GetSnacks()[i], TestData.GetSnacks()[i + 1]);
                list.Add(food);
            }
            foodListView.ItemsSource = list;
        }
    }
}
