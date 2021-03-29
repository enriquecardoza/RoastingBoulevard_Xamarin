using RoastingBoulevard.Data;
using RoastingBoulevard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RoastingBoulevard.ViewModels
{
    class ShoppingCartViewModel:ViewModelBase
    {
        public ShoppingCartViewModel()
        {
            Foods = new ObservableCollection<Food>(SharedData.actualDeliveryFood);
        }


        private ObservableCollection<Food> _food;

        public ObservableCollection<Food> Foods
        {
            get { return this._food; }
            set
            {
                this._food = value;
                OnPropertyChanged(nameof(Foods));
            }
        }

    }
}
