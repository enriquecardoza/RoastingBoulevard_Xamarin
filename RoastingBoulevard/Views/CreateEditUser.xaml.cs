using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoastingBoulevard.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoastingBoulevard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateEditUser : ContentPage
    {
        public CreateEditUser()
        {
            InitializeComponent();
            crearButton.Clicked += CrearUser;
        }

        private void CrearUser(object sender, EventArgs arg)
        {
            User newUser = new User();
            newUser.name = enterName.Text;
            newUser.surname = enterSurname.Text;
            newUser.email = enterEmail.Text;
            newUser.phone = int.Parse(enterPhone.Text);
            newUser.password = enterPassword.Text;
        }

        private bool AllEntriesCorrect()
        {
            if (string.IsNullOrEmpty(enterName.Text) ||
                string.IsNullOrEmpty(enterSurname.Text) ||
                string.IsNullOrEmpty(enterEmail.Text) ||
                string.IsNullOrEmpty(enterPhone.Text) ||
                string.IsNullOrEmpty(enterPassword.Text) ||
                string.IsNullOrEmpty(enterConfirmPassword.Text))
            {
                errortext.Text = "Hay un campo vacio";
                return false;
            }
            else if (enterPassword.Text != enterConfirmPassword.Text)
            {
                errortext.Text = "Las contraseñas no coinciden";
                errortext.TextColor = Color.Red;
                return false;
            }else if (!Tools.Tools.IsValidEmail(enterEmail.Text))
            {
                errortext.Text = "Email no valido";
                errortext.TextColor = Color.Red;
                return false;
            }
            else
            {
                errortext.Text = "Creando usuario";
                errortext.TextColor = Color.Blue;
                return true;
            }
        }
    }
}