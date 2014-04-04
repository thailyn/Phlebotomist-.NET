﻿using Phlebotomist.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels
{
    public class FamiliarsSearchViewModel : INotifyPropertyChanged
    {
        private Phlebotomist.Model.PhlebotomistModelContainer _context;
        protected internal Phlebotomist.Model.PhlebotomistModelContainer Context
        {
            get;
            set;
        }

        private ObservableCollection<FamiliarType> _familiars;
        public ObservableCollection<FamiliarType> Familiars
        {
            get
            {
                if (_familiars == null)
                {
                    _familiars = new ObservableCollection<FamiliarType>(
                        from f in Context.FamiliarTypes
                        select f);
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public FamiliarsSearchViewModel()
        {

        }
    }
}
