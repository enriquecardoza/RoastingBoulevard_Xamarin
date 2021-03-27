using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoastingBoulevard.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RoastingBoulevard.Tools;
using RoastingBoulevard.Data;

namespace RoastingBoulevard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateEditUser : ContentPage
    {

        public CreateEditUser()
        {
            InitializeComponent();
            crearButton.Clicked += CrearUser;
            errortext.Text = "";
        }

        private void CrearUser(object sender, EventArgs arg)
        {
            if (CheckEntriesCorrect())
            {
                User newUser = new User();
                newUser.Name = enterName.Text;
                newUser.Surname = enterSurname.Text;
                newUser.Email = enterEmail.Text;
                newUser.Phone = int.Parse(enterPhone.Text);
                newUser.Password = enterPassword.Text;
                SharedData.user = newUser;
                Task.Run(async () =>
                {

                    int b = await Helpers.HelperUser.CheckIfEmailExists(enterEmail.Text);
                    if (b==1)
                    {
                        Tools.Tools.UseActionMainThread(() =>
                        {

                            Tools.Tools.PushAsync("Escribir direccion de entrega", this.Navigation, new CreateEditAddress());
                        });
                    }
                    else if(b == 0)
                        Tools.Tools.UseActionMainThread(() =>
                        {
                            errortext.Text = "Error al enviar datos, el email ya existe";
                            errortext.TextColor = Color.Red;
                        });
                    else
                        Tools.Tools.UseActionMainThread(() =>
                        {
                            errortext.Text = "Error al enviar datos";
                            errortext.TextColor = Color.Red;
                        });
                });

            }
        }

        private bool CheckEntriesCorrect()
        {
            if (string.IsNullOrEmpty(enterName.Text) ||
                string.IsNullOrEmpty(enterSurname.Text) ||
                string.IsNullOrEmpty(enterEmail.Text) ||
                string.IsNullOrEmpty(enterPhone.Text) ||
                string.IsNullOrEmpty(enterPassword.Text) ||
                string.IsNullOrEmpty(enterConfirmPassword.Text))
            {
                errortext.Text = "Hay un campo vacio";
                errortext.TextColor = Color.Red;
                return false;
            }
            else if (enterPassword.Text != enterConfirmPassword.Text)
            {
                errortext.Text = "Las contraseñas no coinciden";
                errortext.TextColor = Color.Red;
                return false;
            }
            else if (!Tools.Tools.IsValidEmail(enterEmail.Text))
            {
                errortext.Text = "Email no valido";
                errortext.TextColor = Color.Red;
                return false;
            }
            else
            {
                errortext.Text = "Enviando datos";
                errortext.TextColor = Color.Blue;
                return true;
            }
        }
    }
}