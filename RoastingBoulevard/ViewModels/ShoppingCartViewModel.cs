using RoastingBoulevard.Data;
using RoastingBoulevard.Models;
using RoastingBoulevard.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RoastingBoulevard.ViewModels
{
    public class ShoppingCartViewModel : ViewModelBase
    {
        public ShoppingCartViewModel()
        {
            FoodsContainer = new ObservableCollection<FoodDeliveryContainer>();
        }


        private ObservableCollection<FoodDeliveryContainer> Container
        ;

        public ObservableCollection<FoodDeliveryContainer> FoodsContainer
        {
            get { return this.Container
        ; }
            set
            {
                this.Container
         = value;
                OnPropertyChanged(nameof(FoodsContainer));
            }
        }


        public void AddFood(Food food)
        {
            FoodDeliveryContainer cont = null;
            if (FoodsContainer.Count > 0)
                cont = FoodsContainer.FirstOrDefault(x => x.Food == food);
            if (cont != null)
            {
                int pos = FoodsContainer.IndexOf(cont);
                int amoutn = cont.Amount;
                FoodsContainer.Remove(cont);
                FoodsContainer.Insert(pos, new FoodDeliveryContainer
                {
                    Food = food,
                    Amount = amoutn + 1
                });
            }
            else
            {

                FoodsContainer.Add(new FoodDeliveryContainer
                {
                    Food = food,
                    Amount = 1
                });

            }
            SaveChangues();
            // Foods = new ObservableCollection<FoodDeliveryContainer>(SharedData.actualDelivery.foods);
        }

        public void RemoveFood(Food food)
        {
            FoodDeliveryContainer cont = null;
            if (FoodsContainer.Count > 0)
                cont = FoodsContainer.FirstOrDefault(x => x.Food == food);
            if (cont != null)
            {
                int pos = FoodsContainer.IndexOf(cont);
                int amoutn = cont.Amount;
                if (FoodsContainer[pos].Amount - 1 <= 0)
                {
                    FoodsContainer.Remove(cont);
                }
                else
                {
                    FoodsContainer.Remove(cont);
                    FoodsContainer.Insert(pos, new FoodDeliveryContainer
                    {
                        Food = food,
                        Amount = amoutn - 1
                    });
                }
                SaveChangues();
            }
        }

        public void RemoveFullFood(Food food)
        {
            FoodDeliveryContainer cont = null;
            if (FoodsContainer.Count > 0)
                cont = FoodsContainer.FirstOrDefault(x => x.Food == food);
            if (cont != null)
            {
                FoodsContainer.Remove(cont);

                SaveChangues();
            }
        }

        private void SaveChangues()
        {
            if (FoodsContainer.Count <= 0)
            {
                MainTabbedPage.instance.HideShoppingCart();
            }
            OnPropertyChanged(nameof(FoodsContainer));
        }
    }
}
