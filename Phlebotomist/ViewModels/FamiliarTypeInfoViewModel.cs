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
            get
            {
                return Repository.Context;
            }
        }

        private Phlebotomist.Repositories.PhlebotomistRepository _repository;
        protected internal Phlebotomist.Repositories.PhlebotomistRepository Repository
        {
            get;
            set;
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

        private ObservableCollection<FamiliarTypeViewModel> _familiarTypes;
        public ObservableCollection<FamiliarTypeViewModel> FamiliarTypes
        {
            get
            {
                if (_familiarTypes == null)
                {
                    /*
                    _familiarTypes = new ObservableCollection<FamiliarTypeViewModel>(
                        from f in Context.FamiliarTypes
                        orderby f.Name
                        select new FamiliarTypeViewModel(f, Repository));
                     * */

                    var familiarTypesTemp = new ObservableCollection<FamiliarType>(
                        from f in Context.FamiliarTypes
                        orderby f.Name
                        select f);

                    _familiarTypes = new ObservableCollection<FamiliarTypeViewModel>();
                    foreach (var familiar in familiarTypesTemp)
                    {
                        _familiarTypes.Add(new FamiliarTypeViewModel(familiar, Repository));
                    }
                }
                return _familiarTypes;
            }
            set
            {
                if (_familiarTypes != value)
                {
                    _familiarTypes = value;
                    OnPropertyChanged("FamiliarTypes");
                }
            }
        }

        public FamiliarTypeInfoViewModel()
        {

        }

        public void NewFamiliarTypeSelection(FamiliarTypeViewModel selectedFamiliarType)
        {
            SelectedFamiliarType = selectedFamiliarType;
        }

        public void NewSelectedFamiliarType()
        {
            SelectedFamiliarType = new FamiliarTypeViewModel(new FamiliarType
                {
                    Id = -1
                }, Repository);
        }

        public void ClearPreviousEvolution()
        {
            SelectedFamiliarType.PreviousEvolution = null;
        }

        public bool SaveSelectedFamiliarType()
        {
            var familiar = SelectedFamiliarType;

            if (familiar == null)
            {
                return false;
            }

            familiar.Save();

            //Context.SaveChanges();

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
