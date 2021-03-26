using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoastingBoulevard.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RoastingBoulevard.Tools;

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
               
                Task.Run(async () =>
                {
                    bool b = await Helpers.HelperUser.InsertUser(newUser);
                    if (b)
                    {
                        Tools.Tools.UseActionMainThread(()=> {
                            errortext.Text = "Datos guardados";
                        });
                        Tools.Tools.PopToRootAsync(this.Navigation);
                    }
                    else
                        Tools.Tools.UseActionMainThread(() => {
                            errortext.Text = "Error al enviar datos, el email ya existe";
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