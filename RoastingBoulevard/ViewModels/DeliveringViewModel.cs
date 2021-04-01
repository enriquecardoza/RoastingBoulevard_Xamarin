using System;
using System.Collections.Generic;
using System.Text;

namespace RoastingBoulevard.ViewModels
{
    class DeliveringViewModel:ViewModelBase
    {

        public DeliveringViewModel()
        {

        }

        private string _estado;
        public string Estado
        {
            get { return this._estado; }
            set
            {
                this._estado = value;
                OnPropertyChanged(nameof(Estado));
            }
        }
        private float _progreso;
        public float Progreso
        {
            get { return this._progreso; }
            set
            {
                this._progreso = value;
                OnPropertyChanged(nameof(Progreso));
            }
        }
    }
}
