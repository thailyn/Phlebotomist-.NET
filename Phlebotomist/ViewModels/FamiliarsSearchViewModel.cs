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
    class FamiliarsSearchViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<FamiliarType> _familiars;
        public ObservableCollection<FamiliarType> Familiars
        {
            get
            {
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
            /*
            Familiars.Add(new FamiliarType
                {
                    Name = "Thor"
                });
            Familiars.Add(new FamiliarType
                {
                    Name = "Odin"
                });
             * */
        }
    }
}
