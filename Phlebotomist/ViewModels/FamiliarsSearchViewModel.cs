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
            Familiars = new ObservableCollection<FamiliarType>();

            var context = new Phlebotomist.Model.PhlebotomistModelContainer();
            var selectedRarity = (from r in context.Rarities1
                                  select r).ToList().FirstOrDefault();

            Familiars.Add(new FamiliarType
                {
                    Name = "Thor",
                    Worth = 7000,
                    RarityId = selectedRarity.Id,
                    Rarity = selectedRarity
                });
            Familiars.Add(new FamiliarType
                {
                    Name = "Odin"
                });
        }
    }
}
