using RoastingBoulevard.Data;
using RoastingBoulevard.Models;
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
    public partial class CreateEditAddress : ContentPage
    {

        public CreateEditAddress()
        {
            InitializeComponent();
            errortext.Text = "";
            enterCity.Text = SharedData.user.City;
            enterCodigo.Text = SharedData.user.PostalCode.ToString();
            enterDireccion.Text = SharedData.user.Address;
            enterNumber.Text = SharedData.user.Number.ToString();
            crearButton.Clicked += EditarAddress;
            Spinnertype.SelectedItem = SharedData.user.Description_Address;
            crearButton.Text = "Editar";
        }
        private User tempuser=new User();
        public CreateEditAddress(User user)
        {
            InitializeComponent();
            errortext.Text = "";
            crearButton.Clicked += CrearAddress;
            crearButton.Text = "Crear";
            tempuser = user;
        }
        public void CrearAddress(object sender, EventArgs arg)
        {
            tempuser.Address = enterDireccion.Text;
            tempuser.Number = int.Parse(enterNumber.Text);
            tempuser.PostalCode = int.Parse(enterCodigo.Text);
            tempuser.City = enterCity.Text;
            tempuser.Description_Address = Spinnertype.SelectedItem.ToString();
            Task.Run(async () =>
            {
                bool b = await Helpers.HelperUser.InsertUser(tempuser);
                if (b)
                {
                    Tools.Tools.UseActionMainThread(() =>
                    {
                        errortext.Text = "Datos guardados";
                    });
                    Tools.Tools.PopToRootAsync(this.Navigation);
                    MainTabbedPage.instance.ChangueLoginToProfilePage();
                    SharedData.user = tempuser;
                }
                else
                    Tools.Tools.UseActionMainThread(() =>
                    {
                        errortext.Text = "Error al enviar datos";
                    });


            });
        }

        public void EditarAddress(object sender, EventArgs arg)
        {
            if (CheckEntriesCorrect())
            {
                tempuser = SharedData.user;
                tempuser.City = enterCity.Text;
                tempuser.PostalCode = int.Parse(enterCodigo.Text);
                tempuser.Address = enterDireccion.Text;
                tempuser.Number = int.Parse(enterNumber.Text);

                Task.Run(async () =>
                {
                   
                    bool b = await Helpers.HelperUser.EditUser(SharedData.user);
                    if (b)
                        Tools.Tools.UseActionMainThread(() =>
                        {
                            ChangueErrorText("Datos modificados", Color.Blue);
                            SharedData.user=tempuser;
                            Tools.Tools.PopToRootAsync(this.Navigation);
                        });
                    else
                        Tools.Tools.UseActionMainThread(() =>
                        {
                            ChangueErrorText("Error al enviar datos", Color.Red);
                        });
                });
            }
        }
        private bool CheckEntriesCorrect()
        {
            if (string.IsNullOrEmpty(enterCity.Text) ||
                string.IsNullOrEmpty(enterCodigo.Text) ||
                string.IsNullOrEmpty(enterDireccion.Text) ||
                string.IsNullOrEmpty(enterNumber.Text))
            {
                ChangueErrorText("Hay un campo vacio", Color.Red);
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