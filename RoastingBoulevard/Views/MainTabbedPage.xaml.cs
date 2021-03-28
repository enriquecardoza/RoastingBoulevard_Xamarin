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
            mainTabPage.Children.RemoveAt(2);
            mainTabPage.TabIndex = 2;
            mainTabPage.SelectedItem = p;
        }
        public void ChangueProfileToLoginpage()
        {
            Login p = new Login();
            mainTabPage.Children.Add(p);
            mainTabPage.Children.RemoveAt(2);
            mainTabPage.TabIndex = 2;
            mainTabPage.SelectedItem = p;
        }

        public void ChangueSelectedTab(int index)
        {
            mainTabPage.TabIndex = 2;

            Page p = mainTabPage.Children[index];
            mainTabPage.SelectedItem = p;
        }
    }
}
