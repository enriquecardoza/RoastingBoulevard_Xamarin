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
    public partial class DeliveringView 
    {
        private Func<bool, Task> callback;
        DeliveringViewModel dvm;
        public DeliveringView()
        {
            InitializeComponent();
            dvm = new DeliveringViewModel();
            mainGrid.BindingContext = dvm;
            gif.IsAnimationPlaying = true;
        }

        public DeliveringView(Func<bool, Task> callback)
        {
            InitializeComponent();
            dvm = new DeliveringViewModel();
            mainGrid.BindingContext = dvm;
            FrContent.Opacity = 1;
            this.callback = callback;
            UpdateData(0);
            EmpezarTimer();
        }
        public void UpdateData(float estado)
        {
            dvm.Estado = ((Delivery.DeliveryStateEnum)estado).ToString();
            float progreso=(float)((estado) / Enum.GetNames(typeof(Delivery.DeliveryStateEnum)).Length);
            dvm.Progreso = progreso;

        }

        public void EmpezarTimer()
        {
            Task.Run(async () =>
            {
                UpdateData(0);
                Thread.Sleep(2000);
                UpdateData(1);
                Thread.Sleep(2000);
                UpdateData(2);
                Thread.Sleep(2000);
                UpdateData(3);
                Thread.Sleep(10000);
                await callback.Invoke(false);
                Tools.Tools.UseActionMainThread(() =>
                {
                    DisplayAlert("Tu pedido", "Tu pedido ya deberia de estar aqui ", "Entendido");
                });
            });
        }

        public void Close(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await callback.Invoke(false);
            });
        }
    }
}