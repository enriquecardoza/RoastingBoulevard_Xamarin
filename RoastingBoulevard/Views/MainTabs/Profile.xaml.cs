using RoastingBoulevard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoastingBoulevard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            changueDirection.Clicked += (object sender, EventArgs arg) =>
            {
                Tools.Tools.PushAsync("Editar dirección", this.Navigation, new CreateEditAddress());
            };
            changueData.Clicked += (object sender, EventArgs arg) =>
            {
                Tools.Tools.PushAsync("Editar datos", this.Navigation, new CreateEditUser());
            };
            seeDeliveies.Clicked += (object sender, EventArgs arg) =>
            {
                Tools.Tools.PushAsync("Pedidos", this.Navigation, new DeliveriesList());
            };
            closeSession.Clicked += (object sender, EventArgs arg) =>
            {
                SharedData.user = null;
                MainTabbedPage.instance.ChangueProfileToLoginpage();
                Preferences.Remove("userEmail");
                Preferences.Remove("userPass");
            };
            if (SharedData.user != null)
                saludo.Text = "Hola " + SharedData.user.Name;
        }
    }
}