using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlebotomist.ViewModels
{
    public class BrigadesViewModel
    {
        protected internal BrigadesSearchViewModel SearchViewModel { get; set; }
        protected internal FamiliarsSearchViewModel FamiliarTypesSearchViewModel { get; set; }
        protected internal BrigadeInfoViewModel InfoViewModel { get; set; }

        public BrigadesViewModel(BrigadesSearchViewModel searchViewModel, FamiliarsSearchViewModel familiarTypesSearchViewModel,
            BrigadeInfoViewModel infoViewModel)
        {
            SearchViewModel = searchViewModel;
            FamiliarTypesSearchViewModel = familiarTypesSearchViewModel;
            InfoViewModel = infoViewModel;
        }

        public void FamiliarTypesUpdated()
        {
            FamiliarTypesSearchViewModel.FamiliarTypesUpdated();
        }
    }
}
