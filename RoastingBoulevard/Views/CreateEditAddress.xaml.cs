using RoastingBoulevard.Data;
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
            crearButton.Clicked += CrearUsuario;
            errortext.Text = "";
        }



        public void CrearUsuario(object sender, EventArgs arg)
        {
            SharedData.user.Address = enterDireccion.Text;
            SharedData.user.Number = int.Parse(enterNumber.Text);
            SharedData.user.PostalCode = int.Parse(enterCodigo.Text);
            SharedData.user.City = enterCity.Text;
            SharedData.user.Description_Address = Spinnertype.SelectedItem.ToString();
            Task.Run(async () =>
            {
                bool b = await Helpers.HelperUser.InsertUser(SharedData.user);
                if (b)
                {
                    Tools.Tools.UseActionMainThread(() =>
                    {
                        errortext.Text = "Datos guardados";
                    });
                    Tools.Tools.PopToRootAsync(this.Navigation);
                }
                else
                    Tools.Tools.UseActionMainThread(() =>
                    {
                        errortext.Text = "Error al enviar datos";
                    });


            });
        }
    }
}