using RoastingBoulevard.Helpers;
using RoastingBoulevard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace RoastingBoulevard.ViewModels
{
    class FoodsViewModel : ViewModelBase
    {
        FoodHelperAzure helper;

        public FoodsViewModel()
        {
            helper = new FoodHelperAzure();
            Task.Run(async () => {
                List<Food> lista = await helper.GetFoods();
                this.Foods = new ObservableCollection<Food>(lista);
            });
        }

        private ObservableCollection<Food> _foods;

        public ObservableCollection<Food> Foods
        {
            get { return this._foods; }
            set
            {
                this._foods = value;
                OnPropertyChanged("Food");
            }
        }


    }
}
