using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RoastingBoulevard.Models;
using RoastingBoulevard.Views;
using Xamarin.Forms;

namespace RoastingBoulevard.ViewModels
{
    public class FoodCombineViewModel : ViewModelBase
    {
        private ObservableCollection<FoodCombine> _FoodsCombined;

        public ObservableCollection<FoodCombine> FoodsCombined
        {
            get { return this._FoodsCombined; }
            set
            {
                this._FoodsCombined = value;
                OnPropertyChanged(nameof(FoodsCombined));
            }
        }

        public static ICommand TabButtonPressed
        {
            get
            {
                return new Command(async (object componentIdentifier) =>
                {
                    onTabPressed(componentIdentifier);
                });
            }
            set {

                int n;
            }
        }

        public static void onTabPressed(object componentIdentifier)
        {
            Dishes.instance.DisplayAlert("al",componentIdentifier.ToString(),"ok");
            if (componentIdentifier is string)
            {
                switch ((string)componentIdentifier)
                {
                }
            }
        }

    }
}
