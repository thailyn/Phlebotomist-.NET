using Phlebotomist.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels
{
    public class FamiliarTypeInfoViewModel : INotifyPropertyChanged
    {
        private FamiliarType _selectedFamiliarType;
        public FamiliarType SelectedFamiliarType
        {
            get
            {
                return _selectedFamiliarType;
            }
            set
            {
                if (_selectedFamiliarType != value)
                {
                    _selectedFamiliarType = value;
                    OnPropertyChanged("SelectedFamiliarType");
                }
            }
        }

        private ObservableCollection<Rarity> _rarities;
        public ObservableCollection<Rarity> Rarities
        {
            get
            {
                return _rarities;
            }
            set
            {
                if (_rarities != value)
                {
                    _rarities = value;
                    OnPropertyChanged("Rarities");
                }
            }
        }

        public FamiliarTypeInfoViewModel()
        {
            var context = new Phlebotomist.Model.PhlebotomistModelContainer();
            Rarities = new ObservableCollection<Rarity>(
                from r in context.Rarities1
                select r);
        }

        public void NewFamiliarTypeSelection(FamiliarType selectedFamiliarType)
        {
            SelectedFamiliarType = selectedFamiliarType;
        }

        public bool SaveSelectedFamiliarType()
        {
            var familiar = SelectedFamiliarType;
            return false;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
