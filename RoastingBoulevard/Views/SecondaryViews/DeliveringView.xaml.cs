using RoastingBoulevard.Models;
using RoastingBoulevard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoastingBoulevard.Views.SecondaryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeliveringView : ContentPage
    {

        DeliveringViewModel dvm = new DeliveringViewModel();
        public DeliveringView()
        {
            InitializeComponent();
            mainGrid.BindingContext = dvm;
        }

        public void UpdateData(int estado)
        {
            dvm.Estado = ((Delivery.DeliveryStateEnum)estado).ToString();
            dvm.Progreso = estado/Enum.GetNames(typeof(Delivery.DeliveryStateEnum)).Length;

        }

        public void EmpezarTimer()
        {
            Task.Run(async () => {
                UpdateData(0);
                Thread.Sleep(1000);
                UpdateData(1);
                Thread.Sleep(1000);
                UpdateData(2);
                Thread.Sleep(1000);
                UpdateData(3);
            });
        }
        

    }
}