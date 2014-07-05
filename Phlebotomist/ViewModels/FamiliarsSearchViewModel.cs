using Phlebotomist.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Phlebotomist.ViewModels
{
    public class FamiliarsSearchViewModel : INotifyPropertyChanged
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

        private ObservableCollection<FamiliarTypeViewModel> _familiars;
        public ObservableCollection<FamiliarTypeViewModel> Familiars
        {
            get
            {
                if (_familiars == null)
                {
                    /*
                    _familiars = new ObservableCollection<FamiliarType>(
                        from f in Context.FamiliarTypes
                        select f);
                     * */

                    var familiarsTemp = new ObservableCollection<FamiliarType>(
                        Context.FamiliarTypes.Include(f => f.StatValues).OrderBy(f => f.Name));

                    _familiars = new ObservableCollection<FamiliarTypeViewModel>();
                    foreach (var familiar in familiarsTemp)
                    {
                        _familiars.Add(new FamiliarTypeViewModel(familiar, Repository));
                    }
                }
                return _familiars;
            }
            protected set
            {
                if (_familiars != value)
                {
                    _familiars = value;
                    OnPropertyChanged("Familiars");
                }
            }
        }

        public FamiliarsSearchViewModel()
        {

        }

        public void FamiliarTypesUpdated()
        {
            // Blow away the Familiars collection, so it is reloaded
            // from the database the next time it is needed.
            // This is an expensive operation, though, so if we could
            // only do it when a skill is added or deleted, it would
            // be better.
            Familiars = null;
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
