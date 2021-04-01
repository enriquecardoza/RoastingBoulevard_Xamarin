using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoastingBoulevard.Data;
using RoastingBoulevard.Models;
using RoastingBoulevard.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoastingBoulevard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedFood
    {
        private Func<bool, Task> callback;
        private readonly IAlertDialogService alertDialogService;
        Food foodShowed;
        public SelectedFood(Food food, Func<bool, Task> callback)
        {
            InitializeComponent();
            alertDialogService = DependencyService.Get<IAlertDialogService>();
            foodName.Text = food.Name;
            foodDescription.Text = food.Description;
            foodPhoto.Source = food.Photo;
            foodPrice.Text = $"{food.Price}€";
            this.callback = callback;
            List<Image> list = new List<Image>() { iconWheat, iconEggs, iconMilk, iconPeanuts, iconFish, iconCrustacean };


            foreach (Image image in list)
            {
                image.IsVisible = false;
            }
            foreach (Allergen allergen in food.allergens)
            {
                list[allergen.id].IsVisible = true;
            }
            //FrContent.HeightRequest = gridFood.Height + 200 + FrContent.Padding.HorizontalThickness + gridFood.Margin.HorizontalThickness;
            FrContent.Opacity = 1;
            foodShowed = food;
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }

        private async void BtAdd_Clicked(object sender, EventArgs e)
        {
            if (SharedData.loggedUser)
            {
                MainTabbedPage.instance.ShowShoppingCart();
                ShoppingCart.instance.AddToList(foodShowed);
            }
            else
            {
                //Tools.Tools.UseActionMainThread(() => { });
                await DisplayAlert("Necesita estar registrado", "por favor inicie sesión o registrese", "Entendido");
                MainTabbedPage.instance.ChangueSelectedTab(2);
            }

            await callback.Invoke(true);
        }

        private async void BtClose_Clicked(object sender, EventArgs e)
        {
            await callback.Invoke(false);
        }
    }
}
