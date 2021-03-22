using RoastingBoulevard.Helpers;
using RoastingBoulevard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace RoastingBoulevard.ViewModels
{
    class CategoryViewModel : ViewModelBase
    {
        CategoryHelperAzure helper;
        /*public CategoryViewModel()
        {
            helper = new CategoryHelperAzure();
            Task.Run(async () => {
                List<Category> lista = await helper.GetCategories();
                this.Categories = new ObservableCollection<Category>(lista);
            });
        }*/

        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
        {
            get { return this._categories; }
            set
            {
                this._categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }


    }
}
