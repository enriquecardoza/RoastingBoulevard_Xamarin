using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RoastingBoulevard.Views
{
    public partial class Login : ContentPage
    {

        public Login()
        {
            InitializeComponent();
            registerButton.Clicked += (object sender, EventArgs arg) => {
                Tools.Tools.PushAsync("Crear perfil",this.Navigation,new CreateEditUser()); };
        }


    }
}
