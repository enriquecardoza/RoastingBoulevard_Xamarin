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
        private Action<List<Category>> onCosa = delegate (List<Category> cat) { };
        public Dishes()
        {
            InitializeComponent();
            /*
            tabPageDishes.Children.Add(new FoodListPage());
            
            helper = new CategoryHelperAzure();
            Task.Run(async () => {
               List<Category> categories = await helper.GetCategories();
                // tabPageDishes.ItemsSource = await helper.GetCategories();

                onCosa.Invoke(categories);
            });
            onCosa += (List<Category> lista) => {
                foreach(Category cat in lista)
                {
                    FoodListPage cp = new FoodListPage();
                    cp.Title = cat.Name;
                    tabPageDishes.Children.Add(cp);
                }
            };
            */
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.Animate("", (s) => Layout(new Rectangle(((1 - s) * Width), Y, Width, Height)), 16, 600, Easing.Linear, null, null);
        }
    }
}
