using Phlebotomist.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels
{
    public class BrigadeInfoViewModel : INotifyPropertyChanged
    {
        protected internal Phlebotomist.Model.PhlebotomistModelContainer Context
        {
            get
            {
                return Repository.Context;
            }
        }

        protected internal Phlebotomist.Repositories.PhlebotomistRepository Repository
        {
            get;
            set;
        }

        private BrigadeViewModel _selectedBrigade;
        public BrigadeViewModel SelectedBrigade
        {
            get
            {
                return _selectedBrigade;
            }
            set
            {
                if (_selectedBrigade != value)
                {
                    _selectedBrigade = value;
                    OnPropertyChanged("SelectedBrigade");
                }
            }
        }

        private FamiliarTypeViewModel _selectedFamiliarType;
        public FamiliarTypeViewModel SelectedFamiliarType
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

        public BrigadeInfoViewModel()
        {

        }

        public void NewFamiliarTypeSelection(FamiliarTypeViewModel selectedFamiliarType)
        {
            SelectedFamiliarType = selectedFamiliarType;
        }

        public void NewBrigadeSelection(BrigadeViewModel selectedBrigade)
        {
            SelectedBrigade = selectedBrigade;
        }

        public void NewSelectedBrigade()
        {
            SelectedBrigade = new BrigadeViewModel(new Brigade
            {
                Id = -1
            }, Repository);
        }

        public bool SaveSelectedBrigade()
        {
            var brigade = SelectedBrigade;

            if (brigade == null)
            {
                return false;
            }

            brigade.Save();

            return true;
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
