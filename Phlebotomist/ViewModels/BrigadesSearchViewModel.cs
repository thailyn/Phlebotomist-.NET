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

        private ObservableCollection<BrigadeViewModel> _brigades;
        public ObservableCollection<BrigadeViewModel> Brigades
        {
            get
            {
                if (_brigades == null)
                {
                    var brigadesTemp = new ObservableCollection<Brigade>(
                        Context.Brigades.OrderBy(s => s.Name));

                    _brigades = new ObservableCollection<BrigadeViewModel>();
                    foreach (var brigade in brigadesTemp)
                    {
                        _brigades.Add(new BrigadeViewModel(brigade, Repository));
                    }
                }
                return _brigades;
            }
            protected set
            {
                if (_brigades != value)
                {
                    _brigades = value;
                    OnPropertyChanged("Brigades");
                }
            }
        }

        public void BrigadesUpdated()
        {
            // Blow away the Brigades collection, so it is reloaded
            // from the database the next time it is needed.
            // This is an expensive operation, though, so if we could
            // only do it when a skill is added or deleted, it would
            // be better.
            Brigades = null;
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
