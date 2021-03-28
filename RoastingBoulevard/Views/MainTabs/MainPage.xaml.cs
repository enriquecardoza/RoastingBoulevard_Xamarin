using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RoastingBoulevard.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            startOrderButton.Clicked += (object sender, EventArgs arg) => { 
                MainTabbedPage.instance.ChangueSelectedTab(2); 
            };
        }
    }
}
