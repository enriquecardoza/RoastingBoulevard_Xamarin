using RoastingBoulevard.Data;
using RoastingBoulevard.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RoastingBoulevard.Views
{
    public partial class Login : ContentPage
    {

        public Login()
        {
            InitializeComponent();
            registerButton.Clicked += (object sender, EventArgs arg) =>
            {
                Tools.Tools.PushAsync("Crear perfil", this.Navigation, new CreateEditUser());
            };
            loginButton.Clicked += LoadUser;
            errorInfo.Text = "";
        }

        private void LoadUser(object sender, EventArgs arg)
        {
            Task.Run(async () =>
            {
                User fulluser = await Helpers.HelperUserAzure.GetUser(emailEntry.Text, passwordEntry.Text);
                if (fulluser != null)
                {
                    Tools.Tools.UseActionMainThread(() =>
                    {
                        SharedData.user = fulluser;
                        MainTabbedPage.instance.ChangueLoginToProfilePage();
                        errorInfo.Text = "";
                        Preferences.Set("userEmail", SharedData.user.Email);
                        Preferences.Set("userPass", SharedData.user.Password);
                    });
                }
                else
                {
                    Tools.Tools.UseActionMainThread(() =>
                    {
                        errorInfo.Text = "Email o contraseña incorrecto";
                    });
                }
            });
        }


    }
}
