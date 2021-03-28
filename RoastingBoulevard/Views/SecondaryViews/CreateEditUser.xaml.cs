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
        private bool isEditing => SharedData.user != null;
        public CreateEditUser()
        {
            InitializeComponent();

            errortext.Text = "";

            if (isEditing)
            {
                enterName.Text = SharedData.user.Name;
                enterSurname.Text = SharedData.user.Surname;
                enterEmail.Text = SharedData.user.Email;
                enterPhone.Text = SharedData.user.Phone.ToString();
                SetVisiblePassword(false);
                crearButton.Clicked += EditarUser;
                crearButton.Text = "Editar";
            }
            else
            {
                SetVisiblePassword(true);
                crearButton.Clicked += CrearUser;
                crearButton.Text = "Añadir dirección";
            }
        }

        private void SetVisiblePassword(bool visible)
        {
            enterPassword.IsVisible = visible;
            enterConfirmPassword.IsVisible = visible;
            infoConfirmPassword.IsVisible = visible;
            infoEnterPassword.IsVisible = visible;
        }
        private void CrearUser(object sender, EventArgs arg)
        {
            if (CheckEntriesCorrect())
            {
                User newUser = new User
                {
                    Name = enterName.Text,
                    Surname = enterSurname.Text,
                    Email = enterEmail.Text,
                    Phone = int.Parse(enterPhone.Text),
                    Password = enterPassword.Text
                };
                Task.Run(async () =>
                {

                    int b = await Helpers.HelperUser.CheckIfEmailExists(enterEmail.Text);
                    if (b == 1)
                    {
                        Tools.Tools.UseActionMainThread(() =>
                        {
                            Tools.Tools.PushAsync("Escribir direccion de entrega", this.Navigation, new CreateEditAddress(newUser));
                        });
                    }
                    else if (b == 0)
                        Tools.Tools.UseActionMainThread(() =>
                        {
                            ChangueErrorText("Error al enviar datos, el email ya existe", Color.Red);
                        });
                    else
                        Tools.Tools.UseActionMainThread(() =>
                        {
                            ChangueErrorText("Error al enviar datos", Color.Red);
                        });
                });

            }
        }
        private void EditarUser(object sender, EventArgs arg)
        {
            if (CheckEntriesCorrect())
            {
                User newUser = SharedData.user;
                newUser.Name = enterName.Text;
                newUser.Surname = enterSurname.Text;
                newUser.Email = enterEmail.Text;
                newUser.Phone = int.Parse(enterPhone.Text);

                Task.Run(async () =>
                {
                    if (newUser.Email != SharedData.user.Email)
                    {
                        int b = await Helpers.HelperUser.CheckIfEmailExists(enterEmail.Text);
                        if (b == 1)
                        {
                            await EditUserAndReturnToRoot(newUser);
                        }
                        else if (b == 0)
                        {
                            Tools.Tools.UseActionMainThread(() =>
                            {
                                ChangueErrorText("Error al enviar datos, el email ya existe", Color.Red);
                            });
                        }
                    }
                    else
                    {
                        await EditUserAndReturnToRoot(newUser);
                    }
                });
            }
        }

        private async Task<bool> EditUserAndReturnToRoot(User newUser)
        {
            
            bool b = await Helpers.HelperUser.EditUser(newUser);
            if (b)
                Tools.Tools.UseActionMainThread(() =>
                {
                    ChangueErrorText("Datos modificados", Color.Blue);
                    Tools.Tools.PopToRootAsync(this.Navigation);
                    SharedData.user = newUser;
                });
            else
                Tools.Tools.UseActionMainThread(() =>
                {
                    ChangueErrorText("Error al enviar datos", Color.Red);
                });
            return b;
        }

        private bool CheckEntriesCorrect()
        {
            if (string.IsNullOrEmpty(enterName.Text) ||
                string.IsNullOrEmpty(enterSurname.Text) ||
                string.IsNullOrEmpty(enterEmail.Text) ||
                string.IsNullOrEmpty(enterPhone.Text))
            {
                ChangueErrorText("Hay un campo vacio", Color.Red);
                return false;

            }
            else if ((string.IsNullOrEmpty(enterConfirmPassword.Text) || string.IsNullOrEmpty(enterConfirmPassword.Text)) && !isEditing)
            {
                ChangueErrorText("La contraseña esta vacia", Color.Red);
                return false;
            }
            else if (enterPassword.Text != enterConfirmPassword.Text)
            {
                ChangueErrorText("Las contraseñas no coinciden", Color.Red);
                return false;
            }
            else if (!Tools.Tools.IsValidEmail(enterEmail.Text))
            {
                ChangueErrorText("Email no valido", Color.Red);
                return false;
            }
            else
            {
                ChangueErrorText("Enviando datos", Color.Blue);
                return true;
            }
        }

        private void ChangueErrorText(string text, Color color)
        {
            errortext.Text = text;
            errortext.TextColor = color;
        }
    }
}