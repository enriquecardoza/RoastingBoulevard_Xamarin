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
            Foods = new ObservableCollection<FoodDeliveryContainer>(SharedData.actualDelivery.Foods);
        }


        private ObservableCollection<FoodDeliveryContainer> _food;

        public ObservableCollection<FoodDeliveryContainer> Foods
        {
            get { return this._food; }
            set
            {
                this._food = value;
                OnPropertyChanged(nameof(Foods));
            }
        }


        public void AddFood(Food food)
        {
            FoodDeliveryContainer cont = null;
            if (Foods.Count > 0)
                cont = Foods.FirstOrDefault(x => x.Food == food);
            if (cont != null)
            {
                int pos = Foods.IndexOf(cont);
                int amoutn = cont.Amount;
                Foods.Remove(cont);
                Foods.Insert(pos, new FoodDeliveryContainer
                {
                    Food = food,
                    Amount = amoutn + 1
                });
            }
            else
            {

                Foods.Add(new FoodDeliveryContainer
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
            if (Foods.Count > 0)
                cont = Foods.FirstOrDefault(x => x.Food == food);
            if (cont != null)
            {
                int pos = Foods.IndexOf(cont);
                int amoutn = cont.Amount;
                if (Foods[pos].Amount - 1 <= 0)
                {
                    Foods.Remove(cont);
                }
                else
                {
                    Foods.Remove(cont);
                    Foods.Insert(pos, new FoodDeliveryContainer
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
            if (Foods.Count > 0)
                cont = Foods.FirstOrDefault(x => x.Food == food);
            if (cont != null)
            {
                Foods.Remove(cont);

                SaveChangues();
            }
        }

        private void SaveChangues()
        {
            if (Foods.Count <= 0)
            {
                MainTabbedPage.instance.HideShoppingCart();
            }
            OnPropertyChanged(nameof(Foods));
        }
    }
}
