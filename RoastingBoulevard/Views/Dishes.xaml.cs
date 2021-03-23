using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoastingBoulevard.Helpers;
using RoastingBoulevard.Models;
using RoastingBoulevard.Tools;
using RoastingBoulevard.ViewModels;
using Xamarin.Forms;

namespace RoastingBoulevard.Views
{
    public partial class Dishes : TabbedPage
    {
        CategoryHelperAzure helper;
        public static Dishes instance;
        public Dishes()
        {
            InitializeComponent();
            instance = this;
            // tabPageDishes.Children.Add(new FoodListPage());

            helper = new CategoryHelperAzure();
            Task.Run(async () =>
            {
                List<Category> categories = await helper.GetCategoriesWithFoods();
                // tabPageDishes.ItemsSource = await helper.GetCategories();

                Tools.Tools.UseActionMainThread(()=> {
                    foreach (Category cat in categories)
                    {
                        FoodListPage cp = new FoodListPage(cat.Foods);
                        cp.Title = cat.Name;
                        tabPageDishes.Children.Add(cp);

                    }
                    tabPageDishes.TabIndex = 0;

                });
            });


        }

        public static async Task AletAsync(String texto)
        {
            await instance.DisplayAlert("Alert", texto, "OK");
        }
    }
}
