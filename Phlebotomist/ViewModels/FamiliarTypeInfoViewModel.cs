using Phlebotomist.Model;
using System;
using System.Collections.Generic;
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

        public FamiliarTypeInfoViewModel()
        {

        }

        public void NewFamiliarTypeSelection(FamiliarType selectedFamiliarType)
        {
            SelectedFamiliarType = selectedFamiliarType;
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
