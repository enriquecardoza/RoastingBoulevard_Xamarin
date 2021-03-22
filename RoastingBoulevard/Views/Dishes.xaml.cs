using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoastingBoulevard.Helpers;
using RoastingBoulevard.Models;
using RoastingBoulevard.Tools;
using Xamarin.Forms;

namespace RoastingBoulevard.Views
{
    public partial class Dishes : TabbedPage
    {
        CategoryHelperAzure helper;

        public Dishes()
        {
            InitializeComponent();

            Task.Run(async () => {
                List<Category> categories = await CategoryHelperAzure.GetCategories();


                foreach(Category cat in categories)
                {
                    var navigationPage = new NavigationPage(new FoodListPage());
                    //navigationPage.IconImageSource = "login.png";
                    navigationPage.Title = cat.name;
                    Children.Add(new FoodListPage());
                }
            });


            /*
            List<FoodCombine> list = new List<FoodCombine>();
            for(int i=0;i< TestData.GetSnacks().Count; i += 2)
            {
                //FoodCombine food = new FoodCombine(TestData.GetSnacks()[i], TestData.GetSnacks()[i + 1]);
                FoodCombine food = new FoodCombine(TestData.GetSnacks()[i], TestData.GetSnacks()[i + 1]);
                list.Add(food);

            }*/
           // foodListView.ItemsSource = list;
        }
    }
}
