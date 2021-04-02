using RoastingBoulevard.Data;
using RoastingBoulevard.Helpers;
using RoastingBoulevard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace RoastingBoulevard.ViewModels
{
    class DeliveryListViewModel:ViewModelBase
    {

        public DeliveryListViewModel()
        {
            Task.Run(async () => {
                List<Delivery> lista = await DeliveryHelperAzure.GetDeliveries(SharedData.user.Id);
                this.Deliveries = new ObservableCollection<Delivery>(lista);
            });
        }

        private ObservableCollection<Delivery> _deliveries;

        public ObservableCollection<Delivery> Deliveries
        {
            get { return this._deliveries; }
            set
            {
                this._deliveries = value;
                OnPropertyChanged(nameof(Deliveries));
            }
        }

    }
}
