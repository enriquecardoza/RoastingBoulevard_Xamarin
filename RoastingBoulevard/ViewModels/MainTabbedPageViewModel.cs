using RoastingBoulevard.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace RoastingBoulevard.ViewModels
{
    class MainTabbedPageViewModel:ViewModelBase
    {
        public MainTabbedPageViewModel()
        {
            Pages = new ObservableCollection<Page>(new List<Page> { new MainPage() {Title="a" }, new Dishes() { Title = "b" }, new Login() { Title = "c" } }) ;
        }

        private ObservableCollection<Page> _pages;

        public ObservableCollection<Page> Pages
        {
            get { return this._pages; }
            set
            {
                this._pages = value;
                OnPropertyChanged(nameof(Pages));
            }
        }

        public void UpdatePage()
        {
            Pages[2] = new Profile();
            OnPropertyChanged(nameof(Pages));
        }
    }
}
