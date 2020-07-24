using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Tools.MVVM.ViewModels
{
    public abstract class CollectionViewModelBase<TViewModel> : ViewModelBase
        where TViewModel : ViewModelBase
    {
        private ObservableCollection<TViewModel> _items;
        private TViewModel _selectedItem;

        public ObservableCollection<TViewModel> Items
        {
            get
            {
                return _items ?? (_items = LoadItems());
            }
        }

        public TViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                Set(ref _selectedItem, value);
            }
        }

        protected abstract ObservableCollection<TViewModel> LoadItems();
    }
}
