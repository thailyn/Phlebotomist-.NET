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
        private Phlebotomist.Model.PhlebotomistModelContainer _context;
        protected internal Phlebotomist.Model.PhlebotomistModelContainer Context
        {
            get;
            set;
        }

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
                if (_rarities == null)
                {
                    _rarities = new ObservableCollection<Rarity>(
                        from r in Context.Rarities1
                        select r);
                }
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

        private ObservableCollection<Growth> _growths;
        public ObservableCollection<Growth> Growths
        {
            get
            {
                if (_growths == null)
                {
                    _growths = new ObservableCollection<Growth>(
                        from g in Context.Growths
                        select g);
                }
                return _growths;
            }
            set
            {
                if (_growths != value)
                {
                    _growths = value;
                    OnPropertyChanged("Growths");
                }
            }
        }

        private ObservableCollection<Race> _races;
        public ObservableCollection<Race> Races
        {
            get
            {
                if (_races == null)
                {
                    _races = new ObservableCollection<Race>(
                        from r in Context.Races
                        select r);
                }
                return _races;
            }
            set
            {
                if (_races != value)
                {
                    _races = value;
                    OnPropertyChanged("Races");
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

        public void NewSelectedFamiliarType()
        {
            SelectedFamiliarType = new FamiliarType
                {
                    Id = -1
                };
        }

        public bool SaveSelectedFamiliarType()
        {
            var familiar = SelectedFamiliarType;

            if (familiar == null)
            {
                return false;
            }

            if (familiar.Id < 0)
            {
                Context.FamiliarTypes.Add(familiar);
            }

            Context.SaveChanges();

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
