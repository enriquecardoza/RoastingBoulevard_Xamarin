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
    public partial class MainTabbedPage : TabbedPage
    {
        public static MainTabbedPage instance;
        private bool shoppingCartShowed = false;
        public MainTabbedPage()
        {
            InitializeComponent();
            MainTabbedPageViewModel vm=new MainTabbedPageViewModel();
            mainTabPage.BindingContext = vm;
            mainTabPage.SelectedItem = 0;
            instance = this;

        }

        public void ChangueLoginToProfilePage()
        {
            Profile p = new Profile();
            mainTabPage.Children.Add(p);
            mainTabPage.Children.Remove(mainTabPage.Children.OfType<Login>().First());
            mainTabPage.TabIndex = mainTabPage.Children.IndexOf(p);
            mainTabPage.SelectedItem = p;
        }
        public void ChangueProfileToLoginpage()
        {
            Login p = new Login();
            mainTabPage.Children.Add(p);
            mainTabPage.Children.Remove(mainTabPage.Children.OfType<Profile>().First());
            mainTabPage.TabIndex = mainTabPage.Children.IndexOf(p);
            mainTabPage.SelectedItem = p;
        }
        public void ShowShoppingCart()
        {
            if (shoppingCartShowed)
                return;
            ShoppingCart p = new ShoppingCart();
            mainTabPage.Children.Insert(2,p);
            shoppingCartShowed = true;
        }
        public void HideShoppingCart()
        {
            if (!shoppingCartShowed)
                return;
            mainTabPage.Children.Remove(mainTabPage.Children.OfType<ShoppingCart>().First());
            shoppingCartShowed = false;
        }
        public void ChangueSelectedTab(int index)
        {
            mainTabPage.TabIndex = 2;

            Page p = mainTabPage.Children[index];
            mainTabPage.SelectedItem = p;
        }

    }
}
