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
    public class BrigadesSearchViewModel : INotifyPropertyChanged
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

        private ObservableCollection<FamiliarTypeViewModel> _familiarTypes;
        public ObservableCollection<FamiliarTypeViewModel> FamiliarTypes
        {
            get
            {
                if (_familiarTypes == null)
                {
                    var familiarTypesTemp = new ObservableCollection<FamiliarType>(
                        Context.FamiliarTypes.OrderBy(s => s.Name));

                    _familiarTypes = new ObservableCollection<FamiliarTypeViewModel>();
                    foreach (var familiarType in familiarTypesTemp)
                    {
                        _familiarTypes.Add(new FamiliarTypeViewModel(familiarType, Repository));
                    }
                }
                return _familiarTypes;
            }
            protected set
            {
                if (_familiarTypes != value)
                {
                    _familiarTypes = value;
                    OnPropertyChanged("Skills");
                }
            }
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
